using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<JsonResult> GetClients()
        {
            return Json(await _clientRepository.GetAll());
        }

        [HttpGet]
        [Route("clients/{id}")]
        public async Task<JsonResult> GetClient(int id)
        {
            return Json(await _clientRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateClient(Client client) => _clientRepository.Create(client);

        [HttpPost]
        [Route("{id}")]
        public void DeleteClient(int id) => _clientRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateClient(Client client) => _clientRepository.Update(client);
    }
}
