using ERP_WCI_Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRState : IRepository<State>
    {
        Task<List<State>> GetListAllAsync(string defaultFilter);
        Task<int> AddStateAsync(State state);
        Task<State> UpdateStateAsync(State state);
    }
}
