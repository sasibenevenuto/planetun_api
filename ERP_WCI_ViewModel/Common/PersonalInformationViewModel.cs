using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Common
{
    public class PersonalInformationViewModel : BaseViewModel
    {
        public int PersonalInformationId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string IndividualResistration { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public List<PhoneNumberPersonalInformationViewModel> PhoneNumbers { get; set; }

        public static implicit operator PersonalInformationViewModel(PersonalInformation model)
        {
            PersonalInformationViewModel viewModel = new PersonalInformationViewModel
            {
                PersonalInformationId = model.PersonalInformationId,
                Name = model.Name,
                IndividualResistration = model.IndividualResistration,
                AddressId = model.AddressId,
                Address = model.Address,
                AddressNumber = model.AddressNumber,
                AddressComplement = model.AddressComplement,
                PhoneNumbers = new List<PhoneNumberPersonalInformationViewModel>()
            };

            model.PhoneNumbers.ForEach(p => viewModel.PhoneNumbers.Add(p));

            return viewModel;
        }
    }
}
