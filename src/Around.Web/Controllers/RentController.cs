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
        private readonly IIoTHub _hub;

        public RentController(
            IRentRepository rentRepository,
            ICopterRepository copterRepository, IIoTHub hub)
        {
            _rentRepository = rentRepository;
            _copterRepository = copterRepository;
            _hub = hub;
        }

        [HttpGet]
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
        [Route("{id}")]
        public async Task<IActionResult> GetRent(int id)
        {
            Rent rent = await _rentRepository.Get(id);
            var response = new RentDto(rent);

            return Ok(response);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetRentByUserId(int userId)
        {
            Rent rent = await _rentRepository.GetByUserId(userId);
            var response = new RentDto(rent);

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRent([FromBody] RentAggregate rentDto)
        {
            var copter = await _copterRepository.Get(rentDto.CopterId);
            if (copter.Status != Status.Ordered)
            {
                var rent = Rent.CreateFromDto(rentDto);
                rent = await _rentRepository.Create(rent);
                await _hub.StartUsingCopter(rent);
                _copterRepository.UpdateStatus(rentDto.CopterId);

                return Ok("Success");
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteRent(int id) => _rentRepository.Delete(id);
    }
}
