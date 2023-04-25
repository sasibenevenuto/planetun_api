using ERP_WCI_Business.General.Interfaces;
using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_Model.General;
using ERP_WCI_Model.Identity;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private Settings _settings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomAuthorizeAttribute _iCustomAuthorizeAttribute;
        private readonly IBUser _bUser;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ICustomAuthorizeAttribute iCustomAuthorizeAttribute,
            IOptions<Settings> settings,
            IBUser bUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iCustomAuthorizeAttribute = iCustomAuthorizeAttribute;
            _settings = settings.Value;
            _bUser = bUser;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] CommandLogin commandLogin)
        {
            try
            {
                var baseCrudViewModel = await _bUser.Authenticate(commandLogin, _settings);
                return StatusCode((int)baseCrudViewModel.Status, baseCrudViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AuthenticateTokenUser")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateTokenUser([FromBody] CommandLogin commandLogin)
        {
            try
            {
                var baseCrudViewModel = await _bUser.AuthenticateTokenUser(commandLogin, _settings);
                return StatusCode((int)baseCrudViewModel.Status, baseCrudViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("CreateNewUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewUser([FromBody] CommandNewUser commandNewUser)
        {
            try
            {
                commandNewUser.LoginToken = _iCustomAuthorizeAttribute.CreateHashTokenIntranet(commandNewUser.Email, commandNewUser.Password);
                var baseReturnCrudViewModel = await _bUser.CreateNewUser(commandNewUser);
                return StatusCode((int)baseReturnCrudViewModel.Status, baseReturnCrudViewModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut("logout")]
        [AllowAnonymous]
        public async Task<ActionResult> Logout([FromQuery] string email)
        {
            try
            {
                return Ok(await _bUser.Logout(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
