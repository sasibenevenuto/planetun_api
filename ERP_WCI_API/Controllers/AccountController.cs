using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_ViewModel.Commands;
using ERP_WCI_ViewModel.Commands.Common.Account;
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
    public class AccountController : ControllerBase
    {
        private readonly IBAccount _accountHandler;
        public AccountController(IBAccount accountHandler)
        {
            _accountHandler = accountHandler;
        }

        [HttpGet("GetAccountById")]
        public async Task<BaseReturnCrudViewModel> GetCompanyById([FromQuery] Guid? accountId)
        {
            try
            {
                if (!accountId.HasValue)
                    throw new Exception("Account ID é obrigatório para esse método!");

                return await _accountHandler.GetAccountByIdAsync(accountId.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("GetListAccountAllPaginator")]
        public async Task<BaseReturnApiViewModel<AccountViewModel>> GetListAccountAllPaginator([FromQuery] CommandPagination commandPagination)
        {
            try
            {
                return await _accountHandler.GetListAccountAllPaginatorAsync(commandPagination);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost()]
        public async Task<BaseReturnCrudViewModel> AddAccount([FromBody] CommandAddAccount commandAddAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _accountHandler.AddAccountAsync(commandAddAccount);
                }
                else
                {
                    throw new Exception("Dados inválidos no modelo");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut()]
        public async Task<BaseReturnCrudViewModel> UpdateAccount([FromBody] CommandUpdateAccount commandAddAccount)
        {
            try
            {
                return await _accountHandler.UpdateAccountAsync(commandAddAccount);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
