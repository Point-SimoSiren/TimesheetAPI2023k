using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetAPI2023k.Models;

namespace TimesheetAPI2023k.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private tuntidbContext db = new tuntidbContext();

        [HttpGet]
        public ActionResult GetAllActiveEmployees()
        {
            try
            {
                var emp = (from e in db.Employees where e.Active == true select e).ToList();

                return Ok(emp);
            }
            catch (Exception e)
            {
                return BadRequest("Error happened: " + e);
            }
        }
    }
}
