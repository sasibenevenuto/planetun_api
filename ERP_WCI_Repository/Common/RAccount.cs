using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common
{
    public class RAccount : Repository<Account>, IRAccount
    {
        public RAccount(Context context) : base(context)
        {

        }

        public async Task<dynamic> AddAccountAsync(Account account)
        {
            try
            {
                return await AddAsync(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Account> GetAccountbyIdAsync(Guid accountId)
        {
            try
            {
                return (await GetListAllAsync(x => x.AccountId == accountId))?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            try
            {
                return await UpdateAsync(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Account>> GetListAccountPaginationOrderByAsync(CommandPagination commandPagination)
        {
            try
            {
                return (await GetListPaginationOrderByAsync(x => x.EmailAccount, commandPagination, x => x.EmailAccount.ToLower().Contains(commandPagination.DefaultFilter.ToLower()), x => x.OrderBy(e => e.EmailAccount))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetListAccountCountAsync(CommandPagination commandPagination)
        {
            try
            {
                return await GetListAllCountAsync(x => x.EmailAccount.ToLower().Contains(commandPagination.DefaultFilter.ToLower()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
