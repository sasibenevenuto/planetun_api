using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ERP_WCI_Business.Planetun.Interfaces;
using ERP_WCI_ViewModel.Planetun;
using ERP_WCI_ViewModel.Commands.Planetun;
using ERP_WCI_API.Helpers;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly IBInspection _inspectionHandler;
        public InspectionController(IBInspection inspectionHandler)
        {
            _inspectionHandler = inspectionHandler;
        }

        [HttpGet("GetListInspectionAll")]
        [ClaimsAuthorize("Inspection", "Get")]
        public async Task<BaseReturnApiViewModel<InspectionViewModel>> GetListInspectionAll([FromQuery] string defaultFilter)
        {
            try
            {
                return await _inspectionHandler.GetListInspectionAllAsync(defaultFilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("GetInspectionById")]
        [ClaimsAuthorize("Inspection", "Get")]
        public async Task<BaseReturnApiViewModel<InspectionViewModel>> GetInspectionById([FromQuery] int inspectionId)
        {
            try
            {
                return await _inspectionHandler.GetInspectionByIdAsync(inspectionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        [ClaimsAuthorize("Inspection", "Post")]
        public async Task<BaseReturnCrudViewModel> AddInspection([FromBody] CommandAddInspection commandAddInspection)
        {
            try
            {
                return await _inspectionHandler.AddInspectionAsync(commandAddInspection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        [ClaimsAuthorize("Inspection", "Put")]
        public async Task<BaseReturnCrudViewModel> UpdateInspection([FromBody] CommandUpdateInspection commandAddInspection)
        {
            try
            {
                return await _inspectionHandler.UpdateInspectionAsync(commandAddInspection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete()]
        [ClaimsAuthorize("Inspection", "Delete")]
        public async Task<BaseReturnCrudViewModel> DeleteInspectionById([FromQuery] int inspectionId)
        {
            try
            {
                return await _inspectionHandler.DeleteInspectionAsync(inspectionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
