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
    public class RCompany : Repository<Company>, IRCompany
    {
        public RCompany(Context context) : base(context)
        {

        }

        public async Task<Guid> AddCompanyAsync(Company company)
        {
            try
            {
                return await AddAsync(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Company> GetCompanybyIdAsync(Guid companyId)
        {
            try
            {
                return (await GetListAllIncludeAsync(x => x.CompanyId == companyId, x => new { x.PhoneNumbers, x.Address })).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCompanyAsync(Guid companyId)
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

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            try
            {
                return await UpdateAsync(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
