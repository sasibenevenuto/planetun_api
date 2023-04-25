using ERP_WCI_Model.Common;
using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Companies.Interfaces
{
    public interface IRCompany : IRepository<Company>
    {
        Task<Guid> AddCompanyAsync(Company company);
        Task<Company> GetCompanybyIdAsync(Guid companyId);
        Task<bool> DeleteCompanyAsync(Guid companyId);
        Task<Company> UpdateCompanyAsync(Company company);
    }
}
