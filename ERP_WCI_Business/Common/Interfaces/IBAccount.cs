using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.Account;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common.Interfaces
{
    public interface IBAccount
    {
        Task<BaseReturnCrudViewModel> AddAccountAsync(CommandAddAccount commandAddAccount);
        Task<BaseReturnCrudViewModel> UpdateAccountAsync(CommandUpdateAccount commandUpdateAccount);        
        Task<BaseReturnCrudViewModel> GetAccountByIdAsync(Guid accountId);
        Task<BaseReturnApiViewModel<AccountViewModel>> GetListAccountAllPaginatorAsync(CommandPagination commandPagination);
    }
}
