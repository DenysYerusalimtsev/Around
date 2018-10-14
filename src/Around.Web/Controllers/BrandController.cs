using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;

        [HttpGet]
        [Route("brands")]
        public JsonResult GetAllBrands()
        {
            var brands = _brandRepository.GetAll();

            return Json(brands);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public JsonResult GetBrand(int id)
        {
            var brand = _brandRepository.Get(id);

            return Json(brand);
        }
    }
}
