using ERP_WCI_Model.Companies;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Companies
{
    public class PhoneNumberCompanyViewModel : PhoneNumberViewModel
    {
        public int PhoneNumberCompanyId { get; set; }
        public Guid CompanyId { get; set; }

        public static implicit operator PhoneNumberCompanyViewModel(PhoneNumberCompany model)
        {
            return new PhoneNumberCompanyViewModel
            {
                PhoneNumberCompanyId = model.PhoneNumberCompanyId,
                CompanyId = model.CompanyId,
                TypePhone = model.TypePhone,
                Number = model.Number,
                MainPhone = model.MainPhone
            };
        }
    }
}
