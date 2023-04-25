using Day3.Data;
using Day3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(UserManager<ApplicationUser> manager)
        {
            Manager = manager;
        }

        public UserManager<ApplicationUser> Manager { get; }

        [HttpGet]
        [Route("GetInfoForManager")]
        [Authorize(Policy = "AdminOnly")]
        public string[] GetInfoForManager()
        {
            return new[] { "#data1 For Admin only", "data2  For Admin only" };
        }

        [HttpGet]
        [Route("GetInfoForUser")]
        [Authorize(Policy = "UserOrAdmin")]
        public string[] GetInfoForUser()
        {
            return new[] { "data1 For Admin Or User", "data2 For Admin Or User" };
        }

        [HttpGet]
        [Route("GetAuthUser")]
        [Authorize]
        public IActionResult GetUser()
        {
            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var usercolor = User.Claims.FirstOrDefault(c => c.Type == "Color");
            return Ok(new userData(userName?.Value, usercolor?.Value, userEmail?.Value));
        }
    }
}
