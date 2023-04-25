using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Identity.Interfaces
{
    public interface IBUser
    {
        Task<BaseReturnCrudViewModel> CreateNewUser(CommandNewUser commandNewUser);
        Task<BaseReturnCrudViewModel> Logout(string email);
        Task<BaseReturnCrudViewModel> Authenticate(CommandLogin commandLogin, Settings _settings);
        Task<BaseReturnCrudViewModel> AuthenticateTokenUser(CommandLogin commandLogin, Settings settings);
    }
}
