using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Companies;
using ERP_WCI_ViewModel.Companies;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Companies.Interfaces
{
    public interface IBCompany
    {
        Task<BaseReturnCrudViewModel> AddCompanyAsync(CommandAddCompany commandAddCompany);
        Task<BaseReturnCrudViewModel> UpdateCompanyAsync(CommandUpdateCompany commandUpdateCompany);
        Task<BaseReturnCrudViewModel> DeleteCompanyAsync(Guid companyId);
        Task<BaseReturnCrudViewModel> GetCompanyByIdAsync(Guid companyId);
    }
}
