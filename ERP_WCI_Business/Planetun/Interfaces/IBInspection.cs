using ERP_WCI_ViewModel.Commands.Identity;
using ERP_WCI_ViewModel.Commands.Planetun;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Identity;
using ERP_WCI_ViewModel.Planetun;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Planetun.Interfaces
{
    public interface IBInspection
    {
        Task<BaseReturnCrudViewModel> AddInspectionAsync(CommandAddInspection commandAddInspection);
        Task<BaseReturnCrudViewModel> UpdateInspectionAsync(CommandUpdateInspection commandUpdateInspection);
        Task<BaseReturnCrudViewModel> DeleteInspectionAsync(int InspectionId);
        Task<BaseReturnApiViewModel<InspectionViewModel>> GetInspectionByIdAsync(int InspectionId);
        Task<BaseReturnApiViewModel<InspectionViewModel>> GetListInspectionAllAsync(string defaultFilter);
    }
}
