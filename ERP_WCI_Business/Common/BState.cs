using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_Model.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_ViewModel.Commands.Common.State;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common
{
    public class BState : IBState
    {
        private readonly IRState _rState;
        public BState(IRState rState)
        {
            _rState = rState;
        }

        public async Task<BaseReturnCrudViewModel> AddStateAsync(CommandAddState commandAddState)
        {
            var stateId = await _rState.AddStateAsync(new State()
            {
                Name = commandAddState.Name,
                ExternalCode = commandAddState.ExternalCode,
                FederativeUnit = commandAddState.FederativeUnit
            });

            return new BaseReturnCrudViewModel() { ReturnValue = stateId, ReturnMessage = "Estado Gravado com sucesso!" };
        }

        public async Task<StateViewModel> UpdateStateAsync(CommandUpdateState commandUpdateState)
        {
            return await _rState.UpdateStateAsync(new State()
            {
                StateId = commandUpdateState.StateId,
                Name = commandUpdateState.Name,
                ExternalCode = commandUpdateState.ExternalCode,
                FederativeUnit = commandUpdateState.FederativeUnit
            });
        }

        public async Task<BaseReturnApiViewModel<StateViewModel>> GetListStatesAllAsync(string defaultFilter)
        {
            var states = new List<StateViewModel>();
            (await _rState.GetListAllAsync(defaultFilter)).ToList().ForEach(c => states.Add(c));

            return new BaseReturnApiViewModel<StateViewModel>()
            {
                ListData = states
            };
        }
    }
}
