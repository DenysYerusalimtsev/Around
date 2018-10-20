using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
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
        public async Task<JsonResult> GetCheques()
        {
            return Json(await _chequeRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("cheques/{id}")]
        public async Task<JsonResult> GetCheques(int id)
        {
            return Json(await _chequeRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateCheques(Cheque cheque) => _chequeRepository.Create(cheque);

        [HttpPost]
        [Route("{id}")]
        public void DeleteCheques(int id) => _chequeRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCheques(Cheque cheque) => _chequeRepository.Update(cheque);
    }
}
