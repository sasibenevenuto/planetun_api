using ERP_WCI_Business.Companies.Interfaces;
using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Model.Companies;
using ERP_WCI_Repository.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_Repository.Companies;
using ERP_WCI_Repository.Companies.Interfaces;
using ERP_WCI_ViewModel.Commands.Companies;
using ERP_WCI_ViewModel.General;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Companies
{
    public class BCompany : IBCompany
    {
        private readonly IRCompany _rCompany;
        private readonly IRAddress _rAddress;
        private readonly IRPhoneNumberCompany _rPhoneNumberCompany;

        public BCompany(
            IRCompany rCompany,
            IRAddress rAddress,
            IRPhoneNumberCompany rPhoneNumberCompany)
        {
            _rCompany = rCompany;
            _rAddress = rAddress;
            _rPhoneNumberCompany = rPhoneNumberCompany;
        }

        public async Task<BaseReturnCrudViewModel> AddCompanyAsync(CommandAddCompany commandAddCompany)
        {
            int? addressId = (await _rAddress.GetListAllAsync(commandAddCompany.Address.PostalCode))?.FirstOrDefault()?.AddressId;
            string returnMessage = null;

            if (!addressId.HasValue)
            {
                addressId = await _rAddress.AddAddressAsync(new Address()
                {
                    PostalCode = commandAddCompany.Address.PostalCode,
                    AddressStreet = commandAddCompany.Address.AddressStreet,
                    Neighborhood = commandAddCompany.Address.Neighborhood,
                    CityId = commandAddCompany.Address.CityId,
                    StateId = commandAddCompany.Address.StateId
                });
            }

            var companyId = await _rCompany.AddCompanyAsync(new Company()
            {
                CompanyId = Guid.NewGuid(),
                AccountId = commandAddCompany.AccountId,
                TradingName = commandAddCompany.TradingName,
                FantasyName = commandAddCompany.FantasyName,
                CNPJ = commandAddCompany.CNPJ,
                StateRegistration = commandAddCompany.StateRegistration,
                CNAE = commandAddCompany.CNAE,
                MunicipalityRegistration = commandAddCompany.MunicipalityRegistration,
                StateRegistrationReplaceTributary = commandAddCompany.StateRegistrationReplaceTributary,
                AddressNumber = commandAddCompany.AddressNumber,
                AddressComplement = commandAddCompany.AddressComplement,
                AddressId = addressId.Value
            });

            foreach (var item in commandAddCompany.PhoneNumbers)
            {
                try
                {
                    await _rPhoneNumberCompany.AddPhoneNumberAsync(new PhoneNumberCompany()
                    {
                        TypePhone = item.TypePhone,
                        Number = item.Number,
                        MainPhone = item.MainPhone,
                        CompanyId = companyId
                    });
                }
                catch (Exception ex)
                {
                    returnMessage += ex.Message;
                }
            }


            return new BaseReturnCrudViewModel() { ReturnValue = companyId, ReturnMessage = returnMessage ?? "Informações da empresa gravadas com sucesso!" };
        }

        public async Task<BaseReturnCrudViewModel> DeleteCompanyAsync(Guid companyId)
        {
            var company = await _rCompany.GetCompanybyIdAsync(companyId);

            foreach (var item in company.PhoneNumbers)
            {
                await _rPhoneNumberCompany.DeletePhoneNumberAsync(item.PhoneNumberCompanyId);
            }

            var deleteReturn = await _rCompany.DeleteCompanyAsync(companyId);

            return new BaseReturnCrudViewModel() { ReturnValue = deleteReturn, ReturnMessage = "Informações da empresa apagadas com sucesso!" };
        }

        public async Task<BaseReturnCrudViewModel> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await _rCompany.GetCompanybyIdAsync(companyId);

            return new BaseReturnCrudViewModel() { ReturnValue = company, ReturnMessage = "Informações da empresa!" };
        }

        public async Task<BaseReturnCrudViewModel> UpdateCompanyAsync(CommandUpdateCompany commandUpdateCompany)
        {
            int? addressId = (await _rAddress.GetListAllAsync(commandUpdateCompany.Address.PostalCode))?.FirstOrDefault()?.AddressId;
            string returnMessage = null;

            if (!addressId.HasValue)
            {
                addressId = await _rAddress.AddAddressAsync(new Address()
                {
                    PostalCode = commandUpdateCompany.Address.PostalCode,
                    AddressStreet = commandUpdateCompany.Address.AddressStreet,
                    Neighborhood = commandUpdateCompany.Address.Neighborhood,
                    CityId = commandUpdateCompany.Address.CityId,
                    StateId = commandUpdateCompany.Address.StateId
                });
            }

            var company = await _rCompany.UpdateCompanyAsync(new Company()
            {
                CompanyId = commandUpdateCompany.CompanyId,
                AccountId = commandUpdateCompany.AccountId,
                TradingName = commandUpdateCompany.TradingName,
                FantasyName = commandUpdateCompany.FantasyName,
                CNPJ = commandUpdateCompany.CNPJ,
                StateRegistration = commandUpdateCompany.StateRegistration,
                CNAE = commandUpdateCompany.CNAE,
                MunicipalityRegistration = commandUpdateCompany.MunicipalityRegistration,
                StateRegistrationReplaceTributary = commandUpdateCompany.StateRegistrationReplaceTributary,
                AddressNumber = commandUpdateCompany.AddressNumber,
                AddressComplement = commandUpdateCompany.AddressComplement,
                AddressId = addressId.Value
            });

            try
            {
                await _rPhoneNumberCompany.DeletePhoneNumbersByCompanyIdAsync(company.CompanyId);

                foreach (var item in commandUpdateCompany.PhoneNumbers)
                {

                    await _rPhoneNumberCompany.AddPhoneNumberAsync(new PhoneNumberCompany()
                    {
                        TypePhone = item.TypePhone,
                        Number = item.Number,
                        MainPhone = item.MainPhone,
                        CompanyId = company.CompanyId
                    });
                }
            }
            catch (Exception ex)
            {
                returnMessage += ex.Message;
            }


            return new BaseReturnCrudViewModel() { ReturnValue = company, ReturnMessage = returnMessage ?? "Informações da empresa alteradas com sucesso!" };
        }
    }
}
