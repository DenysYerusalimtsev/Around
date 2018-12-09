using System.Collections.Generic;
using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Around.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    public class ChequeController : Controller
    {
        private readonly IChequeRepository _chequeRepository;

        public ChequeController(IChequeRepository chequeRepository)
        {
            _chequeRepository = chequeRepository;
        }

        [HttpGet]
        [Route("cheques")]
        public async Task<IActionResult> GetCheques()
        {
            List<Cheque> cheques = await _chequeRepository.GetAllAsync();
            var response = new List<ChequeDto>();

            foreach (var cheque in cheques)
            {
                response.Add(new ChequeDto(cheque));
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("cheques/{id}")]
        public IActionResult GetCheques(int id)
        {
            return Ok(_chequeRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateCheques([FromBody] ChequeAggregate chequeDto)
        {
            var cheque = new Cheque().CreateFromDto(chequeDto);
            _chequeRepository.Create(cheque);
            _chequeRepository.AddCost();

            return Ok("Success");      
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCheques(int id) => _chequeRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCheques(Cheque cheque) => _chequeRepository.Update(cheque);
    }
}
