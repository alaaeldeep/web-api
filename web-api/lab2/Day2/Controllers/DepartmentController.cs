using Day2.BL;
using Day2.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase

    {
        private readonly IDepartmentManager departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            this.departmentManager = departmentManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentDetailsReadDto> GetDetails (int id )
        {
            DepartmentDetailsReadDto deparment = departmentManager.GetDetails(id);
            if(deparment is null)
            {
               return NotFound();
            }
            return deparment;
        }
    }
}
