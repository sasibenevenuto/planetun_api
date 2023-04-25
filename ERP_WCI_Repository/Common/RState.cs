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
    public class RState : Repository<State>, IRState
    {
        public RState(Context context) : base(context)
        {

        }

        public async Task<List<State>> GetListAllAsync(string defaultFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(defaultFilter))
                    return (await GetListAllAsync(x => true)).ToList();
                else
                    return (await GetListAllAsync(x => x.Name.ToUpper().Contains(defaultFilter.ToUpper()))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddStateAsync(State state)
        {
            try
            {
                return await AddAsync(state);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<State> UpdateStateAsync(State state)
        {
            try
            {
                return await UpdateAsync(state);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
