using System;
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
        private readonly IMailBox _mailBox;
        private const string PdfContentType = "application/pdf";
        private const string FileName = "AroundCheckReport.pdf";

        public ChequeController(
            IChequeRepository chequeRepository,
            IReportRenderer reportRenderer,
            IMailBox mailBox)
        {
            _chequeRepository = chequeRepository;
            _reportRenderer = reportRenderer;
            _mailBox = mailBox;
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

        [HttpPost]
        [Route("report")]
        public async Task<IActionResult> RenderReport()
        {
            var cheque = await _chequeRepository.GetLastAsync();
            var attachment = _reportRenderer.Render(cheque);
            await _mailBox.Send(attachment);

            return Ok($"Message sent to {cheque.Rent.Client.Email}");
        }

        [HttpPost]
        [Route("r")]
        public async Task<IActionResult> Report()
        {
            var cheque = await _chequeRepository.GetLastAsync();
            var attachment = _reportRenderer.Render(cheque);
            attachment.Position = 0;
            return File(attachment, "application/pdf", "AroundCheque.pdf");
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCheques(int id) => _chequeRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCheques(Cheque cheque) => _chequeRepository.Update(cheque);
    }
}
