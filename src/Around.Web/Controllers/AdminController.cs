using System.Threading.Tasks;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Around.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("admins")]
        public JsonResult GetAdmins()
        {
            return Json(_adminRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("admins/{id}")]
        public async Task<JsonResult> GetAdmin(int id)
        {
            return Json(await _adminRepository.Get(id));
        }

        [HttpPost]
        [Route("create")]
        public void CreateAdmin(Admin admin) => _adminRepository.Create(admin);

        [HttpPost]
        [Route("{id}")]
        public void DeleteAdmin(int id) => _adminRepository.Delete(id);

        [HttpPost]
        [Route("update")]
        public void UpdateAdmin(Admin admin) => _adminRepository.Update(admin);
    }
}