using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Around.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetClients()
        {
            List<Client> clients = await _clientRepository.GetAll();
            var response = new List<ClientDto>();

            foreach (var client in clients)
            {
                response.Add(new ClientDto(client));
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("clients/{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientRepository.Get(id);
            var response = new ClientDto(client);

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateClient([FromBody]ClientAggregate clientDto)
        {
            var client = new Client().CreateFromDto(clientDto);
            _clientRepository.Create(client);
            return Ok("Success");
        }

        [HttpPost]
        [Route("card")]
        public IActionResult AddClientCreditCard([FromBody]CreditCard creditCard, int userId)
        {
            _clientRepository.AddCreditCardAsync(creditCard, userId);
            return Ok("Success");
        }

        [HttpPost]
        [Route("{id}")]
        public void DeleteClient(int id) => _clientRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateClient(Client client) => _clientRepository.Update(client);
       
    }
}
