using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IBWciClaim _claimHandler;
        public ClaimController(IBWciClaim claimHandler)
        {
            _claimHandler = claimHandler;
        }

        [HttpGet("GetListWciClaimAll")]
        public async Task<BaseReturnApiViewModel<WciClaimViewModel>> GetListWciClaimAll([FromQuery] string defaultFilter)
        {
            try
            {
                return await _claimHandler.GetListWciClaimAllAsync(defaultFilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("GetWciClaimById")]
        public async Task<BaseReturnApiViewModel<WciClaimViewModel>> GetWciClaimById([FromQuery] int WciClaimId)
        {
            try
            {
                return await _claimHandler.GetWciClaimByIdAsync(WciClaimId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<BaseReturnCrudViewModel> AddWciClaim([FromBody] CommandAddWciClaim commandAddWciClaim)
        {
            try
            {
                return await _claimHandler.AddWciClaimAsync(commandAddWciClaim);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        public async Task<BaseReturnCrudViewModel> UpdateWciClaim([FromBody] CommandUpdateWciClaim commandAddWciClaim)
        {
            try
            {
                return await _claimHandler.UpdateWciClaimAsync(commandAddWciClaim);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete()]
        public async Task<BaseReturnCrudViewModel> DeleteWciClaimById([FromQuery] int WciClaimId)
        {
            try
            {
                return await _claimHandler.DeleteWciClaimAsync(WciClaimId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
