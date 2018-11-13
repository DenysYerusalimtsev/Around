using System.Collections.Generic;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Web.Models;

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
        public async Task<IActionResult> GetAllBrands()
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            var response = new List<BrandDto>();

            foreach (var brand in brands)
            {
                response.Add(new BrandDto(brand));
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            Brand brand = await _brandRepository.Get(id);
            var response = new BrandDto(brand);
           
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateBrand([FromBody] BrandAggregate brandDto)
        {
            var brand = new Brand(brandDto.Name, brandDto.CountryCode);
            _brandRepository.Create(brand);

            return Ok("Success");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            _brandRepository.Delete(id);

            return Ok("Success");
        }


        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateBrand(int id, [FromBody] BrandAggregate brandDto)
        {
            var brand = new Brand(brandDto.Name, brandDto.CountryCode);
            _brandRepository.Update(id, brand);

            return Ok("Success");
        }
    }
}
