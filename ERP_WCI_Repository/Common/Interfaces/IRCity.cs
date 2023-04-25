using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRCity : IRepository<City>
    {
        Task<List<City>> GetListCityPaginationOrderByIncludeAsync(BasePagination pagination);
        Task<int> GetListCityCountAsync(BasePagination pagination);
        Task<int> AddCityAsync(City city);
    }
}
