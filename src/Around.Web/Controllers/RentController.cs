using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Enums;
using Around.Core.Interfaces;
using Around.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    public class RentController : Controller
    {
        private readonly IRentRepository _rentRepository;
        private readonly ICopterRepository _copterRepository;

        public RentController(
            IRentRepository rentRepository,
            ICopterRepository copterRepository)
        {
            _rentRepository = rentRepository;
            _copterRepository = copterRepository;
        }

        [HttpGet]
        [Route("rents")]
        public async Task<IActionResult> GetRents()
        {
            List<Rent> rents = await _rentRepository.GetAllAsync();
            var response = new List<RentDto>();

            foreach (var rent in rents)
            {
                response.Add(new RentDto(rent));
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("rents/{id}")]
        public async Task<IActionResult> GetRent(int id)
        {
            Rent rent = await _rentRepository.Get(id);
            var response = new RentDto(rent);

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateRent(RentAggregate rentDto)
        {
            var copter = _copterRepository.Get(rentDto.CopterId);
            if (copter.Result.Status != Status.Ordered)
            {
                _copterRepository.UpdateStatus(rentDto.CopterId);
                var rent = new Rent().CreateFromDto(rentDto);
                _rentRepository.Create(rent);

                return Ok("Success");
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("{id}")]
        public void DeleteRent(int id) => _rentRepository.Delete(id);
    }
}
