using ERP_WCI_Context;
using ERP_WCI_Model.Companies;
using ERP_WCI_Model.Identity;
using ERP_WCI_Repository.Companies.Interfaces;
using ERP_WCI_Repository.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Identity
{
    public class RWciClaim : Repository<WciClaim>, IRWciClaim
    {
        public RWciClaim(Context context) : base(context)
        {

        }

        public async Task<int> AddWciClaimAsync(WciClaim wciClaim)
        {
            try
            {
                return await AddAsync(wciClaim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WciClaim> GetWciClaimbyIdAsync(int wciClaimId)
        {
            try
            {
                return (await GetListAllAsync(x => x.WciClaimId == wciClaimId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteWciClaimAsync(int wciClaimId)
        {
            try
            {
                await DeleteAsync(x => x.WciClaimId == wciClaimId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WciClaim> UpdateWciClaimAsync(WciClaim wciClaim)
        {
            try
            {
                return await UpdateAsync(wciClaim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<WciClaim>> GetListAllAsync(string defaultFilter)
        {
            try
            {
                return (await GetListAllAsync(x => x.NameType.Contains(defaultFilter))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
