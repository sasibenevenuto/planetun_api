using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.General;

namespace ERP_WCI_ViewModel.Common
{
    public class PhoneNumberPersonalInformationViewModel : PhoneNumberViewModel
    {
        public int PhoneNumberPersonalInformationId { get; set; }
        public int PersonalInformationId { get; set; }        

        public static implicit operator PhoneNumberPersonalInformationViewModel(PhoneNumberPersonalInformation model)
        {
            return new PhoneNumberPersonalInformationViewModel
            {
                PhoneNumberPersonalInformationId = model.PhoneNumberPersonalInformationId,
                PersonalInformationId = model.PersonalInformationId,
                TypePhone = model.TypePhone,
                Number = model.Number,
                MainPhone = model.MainPhone
            };
        }
    }
}
