using ERP_WCI_Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRAddress : IRepository<Address>
    {
        Task<List<Address>> GetListAllAsync(string defaultFilter);
        Task<int> AddAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
    }
}
