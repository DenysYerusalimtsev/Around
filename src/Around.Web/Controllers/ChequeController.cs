using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text;
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
        private const string PdfContentType = "application/pdf";
        private const string FileName = "NeurocheckLogReport.pdf";

        public ChequeController(IChequeRepository chequeRepository, IReportRenderer reportRenderer)
        {
            _chequeRepository = chequeRepository;
            _reportRenderer = reportRenderer;
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
            var stream = new MemoryStream();
            try
            {
                await _reportRenderer.RenderAsync(new MemoryStream(),
                    await _chequeRepository.GetLastAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            stream.Position = 0;

            return File(stream, PdfContentType, FileName);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCheques(int id) => _chequeRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateCheques(Cheque cheque) => _chequeRepository.Update(cheque);
    }
}
