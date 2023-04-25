using ERP_WCI_Context;
using ERP_WCI_Model.Companies;
using ERP_WCI_Repository.Companies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Companies
{
    public class RPhoneNumberCompany : Repository<PhoneNumberCompany>, IRPhoneNumberCompany
    {
        public RPhoneNumberCompany(Context context) : base(context)
        {

        }

        public async Task<int> AddPhoneNumberAsync(PhoneNumberCompany phoneNumber)
        {
            try
            {
                return await AddAsync(phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PhoneNumberCompany>> GetListAllByCompanyAsync(Guid companyId)
        {
            try
            {
                return (await GetListAllAsync(x => x.CompanyId == companyId)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public async Task<bool> DeletePhoneNumberAsync(int phoneNumberCompanyId)
        {
            try
            {
                await DeleteAsync(x => x.PhoneNumberCompanyId == phoneNumberCompanyId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePhoneNumbersByCompanyIdAsync(Guid companyId)
        {
            try
            {
                await DeleteAsync(x => x.CompanyId == companyId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
