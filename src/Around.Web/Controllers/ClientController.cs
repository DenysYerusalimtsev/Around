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
        private readonly IUserService _userService;
        private readonly IDiscountRepository _discountRepository;

        public ClientController(
            IClientRepository clientRepository, 
            IUserService userService, 
            IDiscountRepository discountRepository)
        {
            _clientRepository = clientRepository;
            _userService = userService;
            _discountRepository = discountRepository;
        }

        [HttpGet]
        [Route("clients")]
        public IActionResult GetClients()
        {
            List<Client> clients = _clientRepository.GetAll().Result;

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
            var client = new Client(clientDto);
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
        [Route("update/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientAggregate clientDto)
        {
            _userService.Update(id, clientDto);

            return Ok($"Client {clientDto.FirstName} {clientDto.LastName} with ID: {id} were successfully updated");
        }

        [HttpGet]
        [Route("discounts")]
        public IActionResult GetDiscounts()
        {
            return Ok(_discountRepository.GetAllAsync().Result);
        }
    }
}
