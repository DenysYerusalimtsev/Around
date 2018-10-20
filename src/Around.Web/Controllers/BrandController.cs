using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Around.Core.Entities;

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
        public async Task<JsonResult> GetAllBrands()
        {
            return Json(await _brandRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("brand/{id}")]
        public async Task<JsonResult> GetBrand(int id)
        {
            return Json(await _brandRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateBrand(Brand brand) => _brandRepository.Create(brand);

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteBrand(int id) => _brandRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateBrand(Brand brand) => _brandRepository.Update(brand);
    }
}
