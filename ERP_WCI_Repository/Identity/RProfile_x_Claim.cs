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
    public class RProfile_x_Claim : Repository<Profile_x_Claim>, IRProfile_x_Claim
    {
        public RProfile_x_Claim(Context context) : base(context)
        {

        }

        public async Task<int> AddProfile_x_ClaimAsync(Profile_x_Claim Profile_x_Claim)
        {
            try
            {
                return await AddAsync(Profile_x_Claim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Profile_x_Claim> GetProfile_x_ClaimbyIdAsync(int Profile_x_ClaimId)
        {
            try
            {
                return (await GetListAllAsync(x => x.Profile_x_ClaimId == Profile_x_ClaimId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProfile_x_ClaimAsync(int Profile_x_ClaimId)
        {
            try
            {
                await DeleteAsync(x => x.Profile_x_ClaimId == Profile_x_ClaimId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Profile_x_Claim> UpdateProfile_x_ClaimAsync(Profile_x_Claim Profile_x_Claim)
        {
            try
            {
                return await UpdateAsync(Profile_x_Claim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Profile_x_Claim>> GetProfile_x_ClaimbyClaimIdAsync(int wciClaimId)
        {
            try
            {
                return (await GetListAllAsync(x => x.WciClaimId == wciClaimId)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Profile_x_Claim>> GetProfile_x_ClaimbyProfileIdAsync(int profileId)
        {
            try
            {
                return (await GetListAllAsync(x => x.ProfileId == profileId)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
