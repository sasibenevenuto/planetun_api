using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common
{
    public class RPhoneNumberPersonalInformation : Repository<PhoneNumberPersonalInformation>, IRPhoneNumberPersonalInformation
    {
        public RPhoneNumberPersonalInformation(Context context) : base(context)
        {

        }

        public async Task<List<PhoneNumberPersonalInformation>> GetListAllByPersonalInformationAsync(int personalInformationId)
        {
            try
            {
                return (await GetListAllAsync(x => x.PersonalInformationId == personalInformationId)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddPhoneNumberAsync(PhoneNumberPersonalInformation phoneNumber)
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

        public async Task<bool> DeletePhoneNumberAsync(int phoneNumberId)
        {
            try
            {
                await DeleteAsync(x => x.PhoneNumberPersonalInformationId == phoneNumberId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePhoneNumbersByPersonalInformationIdAsync(int PersonalInformationId)
        {
            try
            {
                await DeleteAsync(x => x.PersonalInformationId == PersonalInformationId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
