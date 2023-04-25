using ERP_WCI_API.Helpers;
using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_ViewModel.Commands.Common.State;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IBState _stateHandler;
        public StatesController(IBState stateHandler)
        {
            _stateHandler = stateHandler;
        }

        [HttpGet("GetListStatesAll")]
        [ClaimsAuthorize("State", "Get")]
        public async Task<BaseReturnApiViewModel<StateViewModel>> GetListStatesAll([FromQuery] string defaultFilter)
        {
            try
            {


                return await _stateHandler.GetListStatesAllAsync(defaultFilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        [ClaimsAuthorize("State", "Post")]
        public async Task<BaseReturnCrudViewModel> AddState([FromBody] CommandAddState commandAddState)
        {
            try
            {
                return await _stateHandler.AddStateAsync(commandAddState);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        [ClaimsAuthorize("State", "Put")]
        public async Task<StateViewModel> UpdateState([FromBody] CommandUpdateState commandAddState)
        {
            try
            {
                return await _stateHandler.UpdateStateAsync(commandAddState);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
