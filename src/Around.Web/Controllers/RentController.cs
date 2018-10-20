using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    public class RentController : Controller
    {
        private readonly IRentRepository _rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet]
        [Route("rents")]
        public async Task<JsonResult> GetRents()
        {
            return Json(await _rentRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("rents/{id}")]
        public async Task<JsonResult> GetRent(int id)
        {
            return Json(await _rentRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateRent(Rent rent) => _rentRepository.Create(rent);

        [HttpPost]
        [Route("{id}")]
        public void DeleteRent(int id) => _rentRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateRent(Rent rent) => _rentRepository.Update(rent);
    }
}
