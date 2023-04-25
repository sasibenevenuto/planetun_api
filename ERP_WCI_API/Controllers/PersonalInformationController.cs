using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.PersonalInformation;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WCI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IBPersonalInformation _personalInformationHandler;
        public PersonalInformationController(IBPersonalInformation personalInformationHandler)
        {
            _personalInformationHandler = personalInformationHandler;
        }

        [HttpGet("GetListPersonalInformationAll")]
        public async Task<BaseReturnApiViewModel<PersonalInformationViewModel>> GetListPersonalInformationAll([FromQuery] CommandPagination commandPagination)
        {
            try
            {
                return await _personalInformationHandler.GetListPersonalInformationAllAsync(commandPagination);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("GetPersonalInformationById")]
        public async Task<BaseReturnCrudViewModel> GetPersonalInformationById([FromQuery] int personalInformationId)
        {
            try
            {
                return await _personalInformationHandler.GetPersonalInformationByIdAsync(personalInformationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<BaseReturnCrudViewModel> AddPersonalInformation([FromBody] CommandAddPersonalInformation commandAddPersonalInformation)
        {
            try
            {
                return await _personalInformationHandler.AddPersonalInformationAsync(commandAddPersonalInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        public async Task<BaseReturnCrudViewModel> UpdatePersonalInformation([FromBody] CommandUpdatePersonalInformation commandAddPersonalInformation)
        {
            try
            {
                return await _personalInformationHandler.UpdatePersonalInformationAsync(commandAddPersonalInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete()]
        public async Task<BaseReturnCrudViewModel> DeletePersonalInformationById([FromQuery] int personalInformationId)
        {
            try
            {
                return await _personalInformationHandler.DeletePersonalInformationAsync(personalInformationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
