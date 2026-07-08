using CartNest.Core.DTOs;
using CartNest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartNest.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthApiController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AuthApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AdminDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.LoginAsync(model);

            if (!result)
            {
                return Unauthorized(new
                {
                    Message = "Invalid Username or Password"
                });
            }

            return Ok(new
            {
                Message = "Login Success"
            });
        }
    }
}