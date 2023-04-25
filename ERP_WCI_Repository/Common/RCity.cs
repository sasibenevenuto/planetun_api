using ERP_WCI_Context;
using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using ERP_WCI_Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common
{
    public class RCity : Repository<City>, IRCity
    {
        public RCity(Context context) : base(context)
        {

        }

        public async Task<List<City>> GetListCityPaginationOrderByIncludeAsync(BasePagination pagination)
        {
            try
            {
                return (await GetListPaginationOrderByInclueAsync(x => x.Name, pagination, x => x.Name.ToUpper().Contains(pagination.DefaultFilter.ToUpper()), x => x.State)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetListCityCountAsync(BasePagination pagination)
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

        public async Task<int> AddCityAsync(City city)
        {
            try
            {
                return await AddAsync(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
