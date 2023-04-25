using ERP_WCI_Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.General.Interfaces
{
    public interface ICustomAuthorizeAttribute
    {
        Task<string> Authenticate(string xSignature, User user);
        string CreateToken(string secret);
        string CreateHashTokenIntranet(string secret, string password);
    }
}
