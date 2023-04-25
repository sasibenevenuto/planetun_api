using ERP_WCI_Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRPhoneNumberPersonalInformation : IRepository<PhoneNumberPersonalInformation>
    {
        Task<List<PhoneNumberPersonalInformation>> GetListAllByPersonalInformationAsync(int personalInformationId);
        Task<int> AddPhoneNumberAsync(PhoneNumberPersonalInformation phoneNumber);
        Task<bool> DeletePhoneNumberAsync(int phoneNumberId);
        Task<bool> DeletePhoneNumbersByPersonalInformationIdAsync(int PersonalInformationId);
    }
}
