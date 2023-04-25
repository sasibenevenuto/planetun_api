using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_Model.Identity;
using ERP_WCI_Repository.Identity.Interfaces;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Identity
{
    public class BWciClaim : IBWciClaim
    {
        private readonly IRWciClaim _rWciClaim;
        private readonly IRProfile_x_Claim _rProfile_x_Claim;

        public BWciClaim(IRWciClaim rWciClaim, IRProfile_x_Claim rProfile_x_Claim)
        {
            _rWciClaim = rWciClaim;
            _rProfile_x_Claim = rProfile_x_Claim;
        }

        public async Task<BaseReturnCrudViewModel> AddWciClaimAsync(CommandAddWciClaim commandAddWciClaim)
        {
            var wciClaimId = await _rWciClaim.AddWciClaimAsync(new WciClaim()
            {
                NickName = commandAddWciClaim.NickName,
                NameType = commandAddWciClaim.NameType,
                Value = commandAddWciClaim.Value
            });

            return new BaseReturnCrudViewModel() { ReturnValue = wciClaimId, ReturnMessage = "Claim gravada com sucesso" };
        }

        public async Task<BaseReturnCrudViewModel> DeleteWciClaimAsync(int wciClaimId)
        {
            var claim = await _rWciClaim.GetWciClaimbyIdAsync(wciClaimId);

            foreach (var item in _rProfile_x_Claim.GetProfile_x_ClaimbyClaimIdAsync(claim.WciClaimId).GetAwaiter().GetResult())
            {
                await _rProfile_x_Claim.DeleteProfile_x_ClaimAsync(item.Profile_x_ClaimId);
            }

            var deleteRerturn = await _rWciClaim.DeleteWciClaimAsync(wciClaimId);

            return new BaseReturnCrudViewModel() { ReturnValue = deleteRerturn, ReturnMessage = "Claim apagadas com sucesso!" };
        }

        public async Task<BaseReturnApiViewModel<WciClaimViewModel>> GetListWciClaimAllAsync(string defaultFilter)
        {
            var claims = new List<WciClaimViewModel>();
            (await _rWciClaim.GetListAllAsync(defaultFilter)).ForEach(c => claims.Add(c));

            return new BaseReturnApiViewModel<WciClaimViewModel>()
            {
                ListData = claims
            };
        }

        public async Task<BaseReturnApiViewModel<WciClaimViewModel>> GetWciClaimByIdAsync(int wciClaimId)
        {
            var claim = await _rWciClaim.GetWciClaimbyIdAsync(wciClaimId);

            return new BaseReturnApiViewModel<WciClaimViewModel>() { Data = claim };
        }

        public async Task<BaseReturnCrudViewModel> UpdateWciClaimAsync(CommandUpdateWciClaim commandUpdateWciClaim)
        {
            var wciClaimId = await _rWciClaim.UpdateWciClaimAsync(new WciClaim()
            {
                WciClaimId = commandUpdateWciClaim.WciClaimId,
                NickName = commandUpdateWciClaim.NickName,
                NameType = commandUpdateWciClaim.NameType,
                Value = commandUpdateWciClaim.Value
            });

            return new BaseReturnCrudViewModel() { ReturnValue = wciClaimId, ReturnMessage = "Claim alterada com sucesso" };
        }
    }
}
