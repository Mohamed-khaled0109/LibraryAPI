using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return BadRequest("Role name is required");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                return BadRequest("Role already exists");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return Ok("Role created successfully");

            return BadRequest(result.Errors);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }

        [HttpDelete("Delete/{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return NotFound("Role not found");

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok("Role deleted successfully");

            return BadRequest(result.Errors);
        }
    }
}
