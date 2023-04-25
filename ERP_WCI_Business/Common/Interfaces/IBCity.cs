using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.City;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common.Interfaces
{
    public interface IBCity
    {
        Task<BaseReturnCrudViewModel> AddCityAsync(CommandAddCity commandAddCity);
        Task<BaseReturnApiViewModel<CityViewModel>> GetListCitiesPaginationIncludeAsync(CommandPagination commandPagination);
    }
}
