using ERP_WCI_Context;
using ERP_WCI_Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace ERP_WCI_API.Helpers
{
    public class IdentityInitializer
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            Context context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {

        }
    }
}
