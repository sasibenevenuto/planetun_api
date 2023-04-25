using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Companies.Interfaces
{
    public interface IRPhoneNumberCompany : IRepository<PhoneNumberCompany>
    {
        Task<int> AddPhoneNumberAsync(PhoneNumberCompany phoneNumber);
        Task<List<PhoneNumberCompany>> GetListAllByCompanyAsync(Guid companyId);
        Task<bool> DeletePhoneNumberAsync(int phoneNumberCompanyId);
        Task<bool> DeletePhoneNumbersByCompanyIdAsync(Guid companyId);
    }
}
