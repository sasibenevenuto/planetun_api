using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_Model.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.City;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Common
{
    public class BCity : IBCity
    {
        private readonly IRCity _rCity;
        public BCity(IRCity rCity)
        {
            _rCity = rCity;
        }

        public async Task<BaseReturnCrudViewModel> AddCityAsync(CommandAddCity commandAddCity)
        {
            var cityId = await _rCity.AddCityAsync(new City()
            {
                Name = commandAddCity.Name,
                ExternalCode = commandAddCity.ExternalCode,
                StateId = commandAddCity.StateId
            });

            return new BaseReturnCrudViewModel() { ReturnValue = cityId, ReturnMessage = "Cidade gravada com sucesso" };
        }

        public async Task<BaseReturnApiViewModel<CityViewModel>> GetListCitiesPaginationIncludeAsync(CommandPagination commandPagination)
        {
            var cities = new List<CityViewModel>();
            (await _rCity.GetListCityPaginationOrderByIncludeAsync(commandPagination)).ToList().ForEach(c => cities.Add(c));

            var count = await _rCity.GetListCityCountAsync(commandPagination);

            return new BaseReturnApiViewModel<CityViewModel>()
            {
                ListData = cities,
                Count = count,
                CurrentPag = commandPagination.PageSkip
            };
        }
    }
}
