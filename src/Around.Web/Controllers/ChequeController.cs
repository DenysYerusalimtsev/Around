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
        private readonly IReportRenderer _reportRenderer;
        private readonly ICopterRepository _copterRepository;
        private readonly IMailBox _mailBox;
        private readonly IIoTHub _hub;

        public ChequeController(
            IChequeRepository chequeRepository,
            IReportRenderer reportRenderer,
            IMailBox mailBox, 
            IIoTHub hub, ICopterRepository copterRepository)
        {
            _chequeRepository = chequeRepository;
            _reportRenderer = reportRenderer;
            _copterRepository = copterRepository;
            _mailBox = mailBox;
            _hub = hub;
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
        public async Task<IActionResult> CreateCheque([FromBody] ChequeAggregate chequeDto)
        {
            var cheque = new Cheque().CreateFromDto(chequeDto);
            var chequeId =_chequeRepository.Create(cheque);
            var updatedCheque = await _chequeRepository.AddCost(chequeId);

            _copterRepository.UpdateStatus(cheque.Rent.CopterId);
            //await _hub.FinishUsingCopterAsync(updatedCheque);
            var attachment = _reportRenderer.Render(cheque);
            //await _mailBox.Send(attachment);

            return Ok($"Check with ID: {cheque.Id} successfully created");
        }

        [HttpPost]
        [Route("report")]
        public async Task<IActionResult> RenderReport()
        {
            var cheque = _chequeRepository.GetLastAsync().Result;
            var attachment = _reportRenderer.Render(cheque);
            await _mailBox.Send(attachment);

            return Ok($"Message sent to {cheque.Rent.Client.Email}");
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCheques(int id) => _chequeRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCheques(Cheque cheque) => _chequeRepository.Update(cheque);
    }
}
