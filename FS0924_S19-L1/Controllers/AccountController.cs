using FS0924_S19_L1.Models.Auth;
using FS0924_S19_L1.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S19_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Jwt _jwtSettings;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            Jwt jwtSettings,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager
        )
        {
            _jwtSettings = jwtSettings;
            _usermanager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
    }
}
