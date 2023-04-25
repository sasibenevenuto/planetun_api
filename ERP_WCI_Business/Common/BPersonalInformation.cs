using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_Model.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.PersonalInformation;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common
{
    public class BPersonalInformation : IBPersonalInformation
    {
        private readonly IRPersonalInformation _rPersonalInformation;
        private readonly IRAddress _rAddress;
        private readonly IRPhoneNumberPersonalInformation _rPhoneNumberPersonalInformation;
        public BPersonalInformation(
            IRPersonalInformation rPersonalInformation,
            IRAddress rAddress,
            IRPhoneNumberPersonalInformation rPhoneNumberPersonalInformation)
        {
            _rPersonalInformation = rPersonalInformation;
            _rAddress = rAddress;
            _rPhoneNumberPersonalInformation = rPhoneNumberPersonalInformation;
        }

        public async Task<BaseReturnCrudViewModel> AddPersonalInformationAsync(CommandAddPersonalInformation commandAddPersonalInformation)
        {
            int? addressId = (await _rAddress.GetListAllAsync(commandAddPersonalInformation.Address.PostalCode))?.FirstOrDefault()?.AddressId;
            string returnMessage = null;

            if (!addressId.HasValue)
            {
                addressId = await _rAddress.AddAddressAsync(new Address()
                {
                    PostalCode = commandAddPersonalInformation.Address.PostalCode,
                    AddressStreet = commandAddPersonalInformation.Address.AddressStreet,
                    Neighborhood = commandAddPersonalInformation.Address.Neighborhood,
                    CityId = commandAddPersonalInformation.Address.CityId,
                    StateId = commandAddPersonalInformation.Address.StateId
                });
            }

            var personalInformationId = await _rPersonalInformation.AddPersonalInformationAsync(new PersonalInformation()
            {
                CompanyId = commandAddPersonalInformation.CompanyId,
                Name = commandAddPersonalInformation.Name,
                IndividualResistration = commandAddPersonalInformation.IndividualResistration,
                AddressId = addressId.Value,
                AddressNumber = commandAddPersonalInformation.AddressNumber,
                AddressComplement = commandAddPersonalInformation.AddressComplement
            });

            foreach (var item in commandAddPersonalInformation.PhoneNumbers)
            {
                try
                {
                    await _rPhoneNumberPersonalInformation.AddPhoneNumberAsync(new PhoneNumberPersonalInformation()
                    {
                        TypePhone = item.TypePhone,
                        Number = item.Number,
                        MainPhone = item.MainPhone,
                        PersonalInformationId = personalInformationId
                    });
                }
                catch (Exception ex)
                {
                    returnMessage += ex.Message;
                }
            }

            return new BaseReturnCrudViewModel() { ReturnValue = personalInformationId, ReturnMessage = returnMessage ?? "Informações pessoais gravadas com sucesso!" };
        }

        public async Task<BaseReturnCrudViewModel> DeletePersonalInformationAsync(int personalInformationId)
        {
            var personalInformation = await _rPersonalInformation.GetPersonalInformationbyIdAsync(personalInformationId);

            foreach (var item in personalInformation.PhoneNumbers)
            {
                await _rPhoneNumberPersonalInformation.DeletePhoneNumberAsync(item.PhoneNumberPersonalInformationId);
            }

            var deleteRerturn = await _rPersonalInformation.DeletePersonalInformationAsync(personalInformationId);

            return new BaseReturnCrudViewModel() { ReturnValue = deleteRerturn, ReturnMessage = "Informações pessoais apagadas com sucesso!" };
        }

        public async Task<BaseReturnApiViewModel<PersonalInformationViewModel>> GetListPersonalInformationAllAsync(CommandPagination commandPagination)
        {
            var personalInformations = new List<PersonalInformationViewModel>();
            (await _rPersonalInformation.GetListPersonalInformationPaginationOrderByIncludeAsync(commandPagination)).ToList().ForEach(c => personalInformations.Add(c));

            var count = await _rPersonalInformation.GetListPersonalInformationCountAsync(commandPagination);

            return new BaseReturnApiViewModel<PersonalInformationViewModel>()
            {
                ListData = personalInformations,
                Count = count,
                CurrentPag = commandPagination.PageSkip
            };
        }

        public async Task<BaseReturnCrudViewModel> GetPersonalInformationByIdAsync(int personalInformationId)
        {
            var personalInformation = await _rPersonalInformation.GetPersonalInformationbyIdAsync(personalInformationId);            

            return new BaseReturnCrudViewModel() { ReturnValue = personalInformation, ReturnMessage = "Informações pessoais!" };
        }

        public async Task<BaseReturnCrudViewModel> UpdatePersonalInformationAsync(CommandUpdatePersonalInformation commandUpdatePersonalInformation)
        {
            int? addressId = (await _rAddress.GetListAllAsync(commandUpdatePersonalInformation.Address.PostalCode))?.FirstOrDefault()?.AddressId;
            string returnMessage = null;

            if (!addressId.HasValue)
            {
                addressId = await _rAddress.AddAddressAsync(new Address()
                {
                    PostalCode = commandUpdatePersonalInformation.Address.PostalCode,
                    AddressStreet = commandUpdatePersonalInformation.Address.AddressStreet,
                    Neighborhood = commandUpdatePersonalInformation.Address.Neighborhood,
                    CityId = commandUpdatePersonalInformation.Address.CityId,
                    StateId = commandUpdatePersonalInformation.Address.StateId
                });
            }

            var personalInformation = await _rPersonalInformation.UpdatePersonalInformationAsync(new PersonalInformation()
            {
                PersonalInformationId = commandUpdatePersonalInformation.PersonalInformationId,
                CompanyId = commandUpdatePersonalInformation.CompanyId,
                Name = commandUpdatePersonalInformation.Name,
                IndividualResistration = commandUpdatePersonalInformation.IndividualResistration,
                AddressId = addressId.Value,
                AddressNumber = commandUpdatePersonalInformation.AddressNumber,
                AddressComplement = commandUpdatePersonalInformation.AddressComplement
            });

            try
            {
                await _rPhoneNumberPersonalInformation.DeletePhoneNumbersByPersonalInformationIdAsync(personalInformation.PersonalInformationId);

                foreach (var item in commandUpdatePersonalInformation.PhoneNumbers)
                {

                    await _rPhoneNumberPersonalInformation.AddPhoneNumberAsync(new PhoneNumberPersonalInformation()
                    {
                        TypePhone = item.TypePhone,
                        Number = item.Number,
                        MainPhone = item.MainPhone,
                        PersonalInformationId = personalInformation.PersonalInformationId
                    });
                }
            }
            catch (Exception ex)
            {
                returnMessage += ex.Message;
            }

            return new BaseReturnCrudViewModel() { ReturnValue = personalInformation, ReturnMessage = returnMessage ?? "Informações pessoais alteradas com sucesso!" };
        }
    }
}
