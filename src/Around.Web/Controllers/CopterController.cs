using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    public class CopterController : Controller
    {
        private readonly ICopterRepository _copterRepository;

        public CopterController(ICopterRepository copterRepository)
        {
            _copterRepository = copterRepository;
        }

        [HttpGet]
        [Route("cheques")]
        public async Task<JsonResult> GetCopter()
        {
            return Json(await _copterRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("cheques/{id}")]
        public async Task<JsonResult> GetCopter(int id)
        {
            return Json(await _copterRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateCopter(Copter copter) => _copterRepository.Create(copter);

        [HttpPost]
        [Route("{id}")]
        public void DeleteCopter(int id) => _copterRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCopter(Copter copter) => _copterRepository.Update(copter);
    }
}
