using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.State;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common.Interfaces
{
    public interface IBState
    {
        Task<BaseReturnCrudViewModel> AddStateAsync(CommandAddState commandAddstate);
        Task<StateViewModel> UpdateStateAsync(CommandUpdateState commandUpdateState);
        Task<BaseReturnApiViewModel<StateViewModel>> GetListStatesAllAsync(string defaultFilter);
    }
}
