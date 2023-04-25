
using ERP_WCI_Model.Companies;
using ERP_WCI_Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Identity.Interfaces
{
    public interface IRWciClaim : IRepository<WciClaim>
    {
        Task<int> AddWciClaimAsync(WciClaim wciClaim);
        Task<WciClaim> GetWciClaimbyIdAsync(int wciClaimId);
        Task<bool> DeleteWciClaimAsync(int wciClaimId);
        Task<WciClaim> UpdateWciClaimAsync(WciClaim wciClaim);
        Task<List<WciClaim>> GetListAllAsync(string defaultFilter);
    }
}
