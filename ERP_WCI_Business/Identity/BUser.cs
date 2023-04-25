using ERP_WCI_Business.General.Interfaces;
using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_Model.General;
using ERP_WCI_Model.Identity;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Identity
{
    public class BUser : IBUser
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomAuthorizeAttribute _iCustomAuthorizeAttribute;
        private Settings _settings;
        public BUser(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ICustomAuthorizeAttribute iCustomAuthorizeAttribute,
            IOptions<Settings> settings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iCustomAuthorizeAttribute = iCustomAuthorizeAttribute;
            _settings = settings.Value;
        }

        public async Task<BaseReturnCrudViewModel> Authenticate(CommandLogin commandLogin, Settings _settings)
        {
            try
            {
                var user = (User)_userManager.FindByNameAsync(commandLogin.UserName).GetAwaiter().GetResult();

                if (user == null)
                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Falha ao se autenticar" };

                var result = _signInManager.CheckPasswordSignInAsync(user, commandLogin.Password, false).Result;

                if (result.Succeeded && user.Active)
                {

                    var token = await _iCustomAuthorizeAttribute.Authenticate(_settings.Secret, user);

                    if (string.IsNullOrEmpty(token))
                        return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Token inválido" };

                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.OK, ReturnValue = new UserViewModel() { Token = token, Name = user.Name }, ReturnMessage = "Sucesso" };
                }

                return new BaseReturnCrudViewModel() { Status = HttpStatusCode.NotAcceptable, ReturnValue = null, ReturnMessage = "Falha ao se autenticar" };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseReturnCrudViewModel> AuthenticateTokenUser(CommandLogin commandLogin, Settings settings)
        {
            try
            {

                User user = _userManager.FindByNameAsync(commandLogin.UserName).GetAwaiter().GetResult();

                if(user == null)
                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Usuário não encontrado, por favor cadastra-se novamente!" };

                var result = _signInManager.CheckPasswordSignInAsync(user, commandLogin.Password, false).Result;

                if (result.Succeeded && user.Active)
                {
                    if (commandLogin.TokenUser != _settings.Secret)
                        return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Falha ao se autenticar" };

                    var token = Guid.NewGuid().ToString();

                    user.SecurityStamp = token;

                    await _userManager.UpdateAsync(user);

                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.OK, ReturnValue = new UserViewModel() { Token = token, Name = "Teste" }, ReturnMessage = "Sucesso" };
                }
                else if (result.Succeeded && !user.Active)
                {
                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Usuário ainda não ativo verifique seu email ou token recebido de ativação" };
                }

                return new BaseReturnCrudViewModel() { Status = HttpStatusCode.Unauthorized, ReturnValue = null, ReturnMessage = "Falha ao se autenticar" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseReturnCrudViewModel> CreateNewUser(CommandNewUser commandNewUser)
        {
            try
            {
                if (!BaseCpfCnpj.ValidateCpfCnpj(commandNewUser.CPF))
                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.NotAcceptable, ReturnValue = false, ReturnMessage = "CPF Inválido" };

                var id = Guid.NewGuid().ToString();

                var user = new User
                {
                    Id = id,
                    UserName = commandNewUser.Email.ToLower(),
                    Name = commandNewUser.Name,
                    NormalizedEmail = commandNewUser.Email.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LoginToken = commandNewUser.LoginToken,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = true,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false,
                    Email = commandNewUser.Email,
                    CPF = commandNewUser.CPF,
                    Active = true,
                    EmailConfirmed = true,
                    CreateDate = DateTime.Now,
                    ModifieldDate = DateTime.Now
                };

                var userEmailCadastrado = _userManager.FindByEmailAsync(commandNewUser.Email).GetAwaiter().GetResult();

                if (userEmailCadastrado != null)
                    return new BaseReturnCrudViewModel() { Status = HttpStatusCode.NotAcceptable, ReturnValue = false, ReturnMessage = "Usuario já cadastrado" };

                var usuario = await _userManager.CreateAsync(user, commandNewUser.Password);

                string strErrorMsg = null;
                usuario.Errors?.ToList().ForEach(strError => strErrorMsg += strError.Code + " - " + strError.Description);

                return new BaseReturnCrudViewModel()
                {
                    Status = usuario.Succeeded ? HttpStatusCode.OK : HttpStatusCode.NotAcceptable,
                    ReturnValue = usuario.Succeeded ? id : usuario.Succeeded.ToString(),
                    ReturnMessage = usuario.Succeeded ? "Usuario cadastrado com sucesso" : strErrorMsg
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseReturnCrudViewModel> Logout(string email)
        {
            try
            {
                var user = _userManager.FindByNameAsync(email).GetAwaiter().GetResult();

                user.SecurityStamp = "";

                await _userManager.UpdateAsync(user);

                _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken").GetAwaiter().GetResult();

                return new BaseReturnCrudViewModel() { Status = HttpStatusCode.OK, ReturnValue = false, ReturnMessage = "Sucesso Logout" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
