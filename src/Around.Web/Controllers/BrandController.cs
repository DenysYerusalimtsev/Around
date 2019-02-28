using System;
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
        private readonly ICountryRepository _countryRepository;

        public BrandController(IBrandRepository brandRepository, ICountryRepository countryRepository)
        {
            _brandRepository = brandRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllAsync();

            var response = new List<BrandDto>();

            foreach (var brand in brands)
            {
                response.Add(new BrandDto(brand));
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(countries);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _brandRepository.Get(id);
            var response = new BrandDto(brand);
           
            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateBrand([FromBody] BrandAggregate brandDto)
        {
            var brand = new Brand(brandDto.Name, brandDto.CountryCode);
            _brandRepository.Create(brand);

            return Ok($"Brand {brand.Name} has ID: {brand.Id}");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            _brandRepository.Delete(id);

            return Ok($"Successfully deleted: brand with ID: {id}");
        }


        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateBrand(int id, [FromBody] BrandAggregate brandDto)
        {
            var brand = new Brand(brandDto.Name, brandDto.CountryCode);
            _brandRepository.Update(id, brand);

            return Ok($"Brand with ID: {brand.Id} successfully updated");
        }
    }
}
