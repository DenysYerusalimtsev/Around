using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        [Route("brands")]
        public JsonResult GetAllBrands()
        {
            var brands = _brandRepository.GetAll();

            return Json(brands);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public async Task<JsonResult> GetBrand(int id)
        {
            var brand = await _brandRepository.Get(id);

            return Json(brand);
        }
    }
}
