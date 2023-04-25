using ERP_WCI_ViewModel.Commands.Companies;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Identity.Interfaces
{
    public interface IBWciClaim
    {
        Task<BaseReturnCrudViewModel> AddWciClaimAsync(CommandAddWciClaim commandAddWciClaim);
        Task<BaseReturnCrudViewModel> UpdateWciClaimAsync(CommandUpdateWciClaim commandUpdateWciClaim);
        Task<BaseReturnCrudViewModel> DeleteWciClaimAsync(int wciClaimId);
        Task<BaseReturnApiViewModel<WciClaimViewModel>> GetWciClaimByIdAsync(int wciClaimId);
        Task<BaseReturnApiViewModel<WciClaimViewModel>> GetListWciClaimAllAsync(string defaultFilter);
    }
}
