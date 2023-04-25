using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRAccount : IRepository<Account>
    {
        Task<dynamic> AddAccountAsync(Account account);
        Task<Account> GetAccountbyIdAsync(Guid accountId);
        Task<Account> UpdateAccountAsync(Account account);
        Task<List<Account>> GetListAccountPaginationOrderByAsync(CommandPagination commandPagination);
        Task<int> GetListAccountCountAsync(CommandPagination commandPagination);
    }
}
