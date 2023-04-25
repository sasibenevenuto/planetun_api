using ERP_WCI_Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Identity.Interfaces
{
    public interface IRProfile_x_Claim : IRepository<Profile_x_Claim>
    {
        Task<int> AddProfile_x_ClaimAsync(Profile_x_Claim Profile_x_Claim);
        Task<Profile_x_Claim> GetProfile_x_ClaimbyIdAsync(int Profile_x_ClaimId);
        Task<bool> DeleteProfile_x_ClaimAsync(int Profile_x_ClaimId);
        Task<Profile_x_Claim> UpdateProfile_x_ClaimAsync(Profile_x_Claim Profile_x_Claim);
        Task<List<Profile_x_Claim>> GetProfile_x_ClaimbyClaimIdAsync(int wciClaimId);
        Task<List<Profile_x_Claim>> GetProfile_x_ClaimbyProfileIdAsync(int profileId);
    }
}
