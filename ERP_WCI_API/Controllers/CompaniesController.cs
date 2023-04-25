using ERP_WCI_Business.Companies.Interfaces;
using ERP_WCI_ViewModel.Commands.Companies;
using ERP_WCI_ViewModel.General;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IBCompany _companyHandler;
        public CompaniesController(IBCompany companyHandler)
        {
            _companyHandler = companyHandler;
        }

        [HttpGet("GetCompanyById")]
        public async Task<BaseReturnCrudViewModel> GetCompanyById([FromQuery] Guid companyId)
        {
            try
            {
                return await _companyHandler.GetCompanyByIdAsync(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<BaseReturnCrudViewModel> AddCompany([FromBody] CommandAddCompany commandAddCompany)
        {
            try
            {
                return await _companyHandler.AddCompanyAsync(commandAddCompany);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        public async Task<BaseReturnCrudViewModel> UpdateCompany([FromBody] CommandUpdateCompany commandAddCompany)
        {
            try
            {
                return await _companyHandler.UpdateCompanyAsync(commandAddCompany);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete()]
        public async Task<BaseReturnCrudViewModel> DeleteCompanyById([FromQuery] Guid companyId)
        {
            try
            {
                return await _companyHandler.DeleteCompanyAsync(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
