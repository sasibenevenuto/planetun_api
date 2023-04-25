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
    public class RAddress : Repository<Address>, IRAddress
    {
        public RAddress(Context context) : base(context)
        {

        }

        public async Task<List<Address>> GetListAllAsync(string defaultFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(defaultFilter))                
                    return (await GetListAllAsync(x => x.PostalCode.ToUpper().Contains(defaultFilter.ToUpper()))).ToList();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAddressAsync(Address address)
        {
            try
            {
                return await AddAsync(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            try
            {
                return await UpdateAsync(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
