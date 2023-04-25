using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.Companies;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Common
{
    public class AccountViewModel : BaseViewModel
    {
        public Guid AccountId { get; set; }
        public string EmailAccount { get; set; }
        public ETypeAccount TypeAccount { get; set; }
        public Guid? CompanyActived { get; set; }
        public CompanyViewModel Company { get; set; }

        public static implicit operator AccountViewModel(Account model)
        {
            var accountsViewModel = new AccountViewModel()
            {
                AccountId = model.AccountId,
                EmailAccount = model.EmailAccount,
                CompanyActived = model.CompanyActived
            };

            return accountsViewModel;
        }
    }
}
