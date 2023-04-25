using ERP_WCI_Context;
using ERP_WCI_Model.Identity;
using ERP_WCI_Repository.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Identity
{

    public class RProfile : Repository<Profile>, IRProfile
    {
        public RProfile(Context context) : base(context)
        {

        }

        public async Task<int> AddProfileAsync(Profile Profile)
        {
            try
            {
                return await AddAsync(Profile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Profile> GetProfilebyIdAsync(int ProfileId)
        {
            try
            {
                return (await GetListAllAsync(x => x.ProfileId == ProfileId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProfileAsync(int ProfileId)
        {
            try
            {
                await DeleteAsync(x => x.ProfileId == ProfileId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Profile> UpdateProfileAsync(Profile Profile)
        {
            try
            {
                return await UpdateAsync(Profile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
