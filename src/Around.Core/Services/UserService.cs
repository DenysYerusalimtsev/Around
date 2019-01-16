using Around.Core.Entities;
using Around.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Around.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IClientRepository _clientRepository;

        public UserService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            Client user = _clientRepository.Get(username).Result;

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<Client> GetById(int id)
        {
            return await _clientRepository.Get(id);
        }

        public Client Create(ClientAggregate clientAggregate)
        {
            // validation
            if (string.IsNullOrWhiteSpace(clientAggregate.Password))
                throw new Exception("Password is required");

            if (_clientRepository.GetAny(clientAggregate.Email).Result)
                throw new Exception("Username \"" + clientAggregate.Email + "\" is already taken");

            CreatePasswordHash(clientAggregate.Password, out var passwordHash, out var passwordSalt);

            var client = new Client(clientAggregate)
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _clientRepository.Create(client);

            return client;
        }

        public async Task Update(int id, ClientAggregate clientAggregate)
        {
            var client = _clientRepository.Get(id).Result;

            if (client == null)
                throw new Exception("User not found");

            if (clientAggregate.Email != client.Email)
            {
                // username has changed so check if the new username is already taken
                if (await _clientRepository.GetAny(clientAggregate.Email))
                    throw new Exception("Username " + clientAggregate.Email + " is already taken");
            }

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(clientAggregate.Password))
            {
                CreatePasswordHash(clientAggregate.Password, out var passwordHash, out var passwordSalt);

                client.PasswordHash = passwordHash;
                client.PasswordSalt = passwordSalt;
            }

            client.Update(clientAggregate);

            _clientRepository.Update(id, client);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
