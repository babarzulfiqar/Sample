using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Core.Domain.MasterData;
using Core.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.MasterData;
using Core.Specifications;
using Core.Specifications.Parameters;
using Core.Interfaces.Generic;
using API.Controllers.Common;
using API.Helpers;
using API.Common;
using System;

namespace API.Controllers.MasterData
{
    [Route("api/master/[controller]")]
    public class AccountController : Controller
    {
        private readonly IGenericRepo<Account> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected readonly LinkGenerator _linkGenerator;

        public AccountController(IGenericRepo<Account> genericRepository,
            IUnitOfWork unitOfWork, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        /// <summary>
        /// List all Accounts, by default sorted by AccountName
        /// </summary>
        /// <remarks>With pagination, you can fetch up to x records per page.</remarks>
        [HttpGet(Name = "GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccounts([FromQuery] AccountSpecParam accountParam)
        {
            try
            {
                var spec = new AccountFilterSpecification(accountParam);
                var countSpec = new AccountWithFiltersForCountSpecification(accountParam);
                var totalItems = await _genericRepository.CountAsync(countSpec);
                var accounts = await _genericRepository.ListAsync(spec);
                if (accountParam.PageIndex > 0 && accountParam.PageSize > 0)
                {
                    PaggingAndSorting paggingAndSorting = new PaggingAndSorting(_linkGenerator);
                    paggingAndSorting.PaggingAndSortingData(HttpContext, totalItems, "GetAccounts", accountParam.PageIndex, accountParam.PageSize);
                }
                var data = _mapper.Map<IReadOnlyList<AccountDto>>(accounts);
                if (data == null) return NotFound(CustomValidations.DataNotFoundResponseObject(accountParam));
                if (data.Count <= 0) return NotFound(CustomValidations.DataNotFoundResponseObject(accountParam));
                return Ok(CustomValidations.SuccessOrErrorReponseType("success", data, ConstantProps.dataListText));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
        /// <summary>
        /// Get Account By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAccountById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AccountDto>> GetAccountById(int id)
        {
            try
            {
                var spec = new AccountFilterSpecification(id);
                var dataFromRepo = await _genericRepository.GetEntityWithSpec(spec);
                if (dataFromRepo == null) return NotFound(CustomValidations.DataNotFoundResponseObject(id));
                return Ok(CustomValidations.SuccessOrErrorReponseType("success", _mapper.Map<AccountDto>(dataFromRepo), ConstantProps.DataFetchSuccess));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
        /// <summary>
        /// Add Account - POST api/Account
        /// </summary>
        /// <param name="Account"></param>
        [HttpPost(Name = "AddAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAccount([FromBody] AccountDto Account)
        {
            try
            {
                if (CustomValidations.NullCheckResponseObject(Account) != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.NullCheckResponseObject(Account));
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.InvalidModelResponseObject(Account));
                }
                var AccountRepo = _mapper.Map<Account>(Account);
                _genericRepository.AddRecord(AccountRepo);
                if (!await _unitOfWork.CompleteAsync())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.BadRequest("Adding", "Account", Account));
                }
                var spec = new AccountFilterSpecification(AccountRepo.AccountId);

                return StatusCode(StatusCodes.Status201Created, (CustomValidations.SuccessOrErrorReponseType(
                    "success",
                    _mapper.Map<AccountDto>(await _genericRepository.GetEntityWithSpec(spec)),
                    ConstantProps.SavedSuccessfullyText)));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Create"));
            }
        }

        // PUT api/Account/5
        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountDto account)
        {
            try
            {
                if (CustomValidations.NullCheckResponseObject(account) != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.NullCheckResponseObject(account));
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.InvalidModelResponseObject(account));
                }
                if (await _genericRepository.GetByIdAsync(account.AccountId) == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, CustomValidations.NullCheckResponseObject(null));
                }
                var AccountRepo = _mapper.Map<Account>(account);
                _genericRepository.UpdateRecord(AccountRepo);
                if (!await _unitOfWork.CompleteAsync())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.BadRequest("Updating", "Account", AccountRepo.AccountId));
                }
                var spec = new AccountFilterSpecification(AccountRepo.AccountId);

                return StatusCode(StatusCodes.Status200OK, CustomValidations.SuccessOrErrorReponseType(
                    "success",
                    _mapper.Map<AccountDto>(await _genericRepository.GetEntityWithSpec(spec)),
                    ConstantProps.SavedSuccessfullyText));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Update"));
            }
        }

        /// <summary>
        /// DELETE api/Account/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var entity = await _genericRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    _genericRepository.DeleteRecord(entity);
                    if (!await _unitOfWork.CompleteAsync())
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.SuccessOrErrorReponseType("error", id, ConstantProps.FailedOnSave("Deleting", "Account")));
                    }
                    return StatusCode(StatusCodes.Status200OK, CustomValidations.SuccessOrErrorReponseType("success", _mapper.Map<AccountDto>(entity), ConstantProps.DeletedSuccessfullyText));
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, CustomValidations.DataNotFoundResponseObject(id));
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Delete"));
            }
        }
    }
}
