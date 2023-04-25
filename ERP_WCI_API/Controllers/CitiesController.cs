using ERP_WCI_API.Helpers;
using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.City;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IBCity _cityHandler;
        public CitiesController(IBCity cityHandler)
        {
            _cityHandler = cityHandler;
        }

        [HttpGet("GetListCitiesPaginationInclude")]
        [ClaimsAuthorize("City", "Get")]
        public async Task<BaseReturnApiViewModel<CityViewModel>> GetListCitiesPaginationInclude([FromQuery] CommandPagination commandPagination)
        {
            try
            {
                return await _cityHandler.GetListCitiesPaginationIncludeAsync(commandPagination);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        [ClaimsAuthorize("City", "Post")]
        public async Task<BaseReturnCrudViewModel> AddCity([FromBody] CommandAddCity commandAddCity)
        {
            try
            {
                return await _cityHandler.AddCityAsync(commandAddCity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
