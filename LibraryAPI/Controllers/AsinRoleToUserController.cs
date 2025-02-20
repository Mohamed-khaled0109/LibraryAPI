using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsinRoleToUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AsinRoleToUserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            // 1. التحقق من وجود المستخدم
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            // 2. التحقق من وجود الدور
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
                return BadRequest("Role does not exist");

            // 3. إضافة المستخدم إلى الدور
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
                return Ok($"User {user.UserName} assigned to role {roleName} successfully");

            return BadRequest(result.Errors);
        }


        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }


        [HttpPost("RemoveRole")]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
                return BadRequest("Role does not exist");

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
                return Ok($"User {user.UserName} removed from role {roleName} successfully");

            return BadRequest(result.Errors);
        }


    }
}
