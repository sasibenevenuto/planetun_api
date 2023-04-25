using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using ERP_WCI_Repository.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.Account;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common
{
    public class BAccount : IBAccount
    {
        private readonly IRAccount _rAccount;
        public BAccount(IRAccount rAccount)
        {
            _rAccount = rAccount;
        }

        public async Task<BaseReturnCrudViewModel> AddAccountAsync(CommandAddAccount commandAddAccount)
        {
            var accountId = Guid.NewGuid();
            await _rAccount.AddAccountAsync(new Account()
            {
                AccountId = accountId,
                EmailAccount = CustomDataValidation.EmailValidate(commandAddAccount.EmailAccount),
                TypeAccount = commandAddAccount.TypeAccount,
                CompanyActived = commandAddAccount.CompanyActived
            });

            return new BaseReturnCrudViewModel() { ReturnValue = accountId, ReturnMessage = "Conta gravada com sucesso" };
        }

        public async Task<BaseReturnCrudViewModel> GetAccountByIdAsync(Guid accountId)
        {
            var account = await _rAccount.GetAccountbyIdAsync(accountId);

            return new BaseReturnCrudViewModel() { ReturnValue = account, ReturnMessage = "Informações da conta!" };
        }

        public async Task<BaseReturnApiViewModel<AccountViewModel>> GetListAccountAllPaginatorAsync(CommandPagination commandPagination)
        {
            var acounts = new List<AccountViewModel>();
            (await _rAccount.GetListAccountPaginationOrderByAsync(commandPagination)).ToList().ForEach(c => acounts.Add(c));

            var count = await _rAccount.GetListAccountCountAsync(commandPagination);

            return new BaseReturnApiViewModel<AccountViewModel>()
            {
                ListData = acounts,
                Count = count,
                CurrentPag = commandPagination.PageSkip
            };
        }

        public async Task<BaseReturnCrudViewModel> UpdateAccountAsync(CommandUpdateAccount commandUpdateAccount)
        {
            var account = await _rAccount.UpdateAccountAsync(new Account()
            {
                AccountId = commandUpdateAccount.AccountId,
                EmailAccount = commandUpdateAccount.EmailAccount,
                TypeAccount = commandUpdateAccount.TypeAccount,
                CompanyActived = commandUpdateAccount.CompanyActived
            });

            return new BaseReturnCrudViewModel() { ReturnValue = account, ReturnMessage = "Conta alterada com sucesso" };
        }
    }
}
