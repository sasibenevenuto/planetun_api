using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using ERP_WCI_Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common
{
    public class RPersonalInformation : Repository<PersonalInformation>, IRPersonalInformation
    {
        public RPersonalInformation(Context context) : base(context)
        {

        }

        public async Task<List<PersonalInformation>> GetListPersonalInformationPaginationOrderByIncludeAsync(BasePagination pagination)
        {
            try
            {
                return (await GetListPaginationOrderByInclueAsync(x => x.Name, pagination, x => x.Name.ToUpper().Contains(pagination.DefaultFilter.ToUpper()), x => new { x.PhoneNumbers, x.Address })).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonalInformation> GetPersonalInformationbyIdAsync(int personalINformationId)
        {
            try
            {
                return (await GetListAllIncludeAsync(x => x.PersonalInformationId == personalINformationId, x => new { x.PhoneNumbers, x.Address })).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddPersonalInformationAsync(PersonalInformation personalInformation)
        {
            try
            {
                return await AddAsync(personalInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetListPersonalInformationCountAsync(BasePagination pagination)
        {
            try
            {
                return (await GetListAllCountAsync(x => x.Name.ToUpper().Contains(pagination.DefaultFilter.ToUpper())));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePersonalInformationAsync(int personalInformationId)
        {
            try
            {
                await DeleteAsync(x => x.PersonalInformationId == personalInformationId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonalInformation> UpdatePersonalInformationAsync(PersonalInformation personalInformation)
        {
            try
            {
                return await UpdateAsync(personalInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

