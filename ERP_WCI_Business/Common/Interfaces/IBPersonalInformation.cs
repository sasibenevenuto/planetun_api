using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.PersonalInformation;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common.Interfaces
{
    public interface IBPersonalInformation
    {
        Task<BaseReturnCrudViewModel> AddPersonalInformationAsync(CommandAddPersonalInformation commandAddPersonalInformation);
        Task<BaseReturnCrudViewModel> UpdatePersonalInformationAsync(CommandUpdatePersonalInformation commandUpdatePersonalInformation);
        Task<BaseReturnCrudViewModel> DeletePersonalInformationAsync(int personalInformationId);
        Task<BaseReturnCrudViewModel> GetPersonalInformationByIdAsync(int personalInformationId);
        Task<BaseReturnApiViewModel<PersonalInformationViewModel>> GetListPersonalInformationAllAsync(CommandPagination commandPagination);
    }
}
