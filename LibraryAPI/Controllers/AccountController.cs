using LibraryAPI.DTO;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Transportation_Company.DTO;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> usermanger;
        private readonly IConfiguration config;
        public string errors = "";
        public AccountController(UserManager<User> _usermanger, IConfiguration _config)
        {

            usermanger = _usermanger;
            config = _config;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser regesterdto)
        {
            if (ModelState.IsValid)
            {
                User app = new User();
                app.UserName = regesterdto.Name;
                app.PhoneNumber = regesterdto.PhoneNumber;
                app.Email = regesterdto.Email;
                IdentityResult result = await usermanger.CreateAsync(app, regesterdto.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        // errors.Add(item.Description);
                        errors += item.Description + " ";


                    }
                    //return BadRequest(string.Join(", ", errors));

                    return BadRequest(errors.Trim());
                }

            }
            return BadRequest(ModelState);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {

            if (ModelState.IsValid == true)
            {

                // ApplcationUser use = await usermanger.FindByNameAsync(user.Email);
                User use = await usermanger.FindByEmailAsync(user.Email);


                if (use != null)
                {
                    bool found = await usermanger.CheckPasswordAsync(use, user.Password);
                    if (found)
                    {
                        //create tokien
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, use.UserName));
                        //***** claims.Add(new Claim(ClaimTypes.NameIdentifier, use.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await usermanger.GetRolesAsync(use);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"],//url web api
                            audience: config["JWT:ValidAudiance"],//url consumer angular
                            claims: claims,
                            expires: DateTime.UtcNow.AddHours(1),
                            signingCredentials: signincred
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });


                    }
                    return Unauthorized();

                }
                return Unauthorized();



            }
            return Unauthorized();




        }
    }
    }
    
