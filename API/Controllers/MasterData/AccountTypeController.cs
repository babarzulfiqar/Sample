using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using API.Common;
using Core.Domain.MasterData;
using Core.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.MasterData;
using Core.Interfaces.Generic;
using API.Helpers;
using Core.Specifications;
using System;

namespace API.Controllers.MasterData
{
    [Route("api/master/[controller]")]
    public class AccountTypeController : Controller
    {
        private readonly IGenericRepo<AccountType> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountTypeController(IGenericRepo<AccountType> genericRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// List all AccountTypes, by default sorted by AccountTypeName
        /// </summary>
        /// <remarks>Without server side pagination.</remarks>
        [HttpGet(Name = "GetAccountTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountTypes(string accountTypeName, bool? isActive)
        {
            try
            {
                var spec = new AccountTypeFilterSpecification(accountTypeName, isActive);
                var accountTypes = await _genericRepository.ListAsync(spec);
                var data = _mapper.Map<IReadOnlyList<AccountTypeDto>>(accountTypes);
                if (data == null) return NotFound(CustomValidations.DataNotFoundResponseObject(accountTypeName));
                if (data.Count <= 0) return NotFound(CustomValidations.DataNotFoundResponseObject(accountTypeName));
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
        /// <summary>
        /// Get AccountType By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAccountTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AccountTypeDto>> GetAccountTypeById(int id)
        {
            try
            {
                var dataFromRepo = await _genericRepository.GetByIdAsync(id);
                if (dataFromRepo == null) return Json(CustomValidations.DataNotFoundResponseObject(id));
                return Ok(CustomValidations.SuccessOrErrorReponseType("success", _mapper.Map<AccountTypeDto>(dataFromRepo), ConstantProps.DataFetchSuccess));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
        /// <summary>
        /// Add AccountType - POST api/AccountType
        /// </summary>
        /// <param name="AccountType"></param>
        [HttpPost(Name = "AddAccountType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAccountType([FromBody] AccountTypeDto accountType)
        {
            try
            {
                if (CustomValidations.NullCheckResponseObject(accountType) != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.NullCheckResponseObject(accountType));
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.InvalidModelResponseObject(accountType));
                }
                var accountTypeRepo = _mapper.Map<AccountType>(accountType);
                _genericRepository.AddRecord(accountTypeRepo);
                if (!await _unitOfWork.CompleteAsync())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.BadRequest("Adding", "AccountType", accountType));
                }

                return StatusCode(StatusCodes.Status201Created, CustomValidations.SuccessOrErrorReponseType(
                    "success",
                    _mapper.Map<AccountTypeDto>(await _genericRepository.GetByIdAsync(accountTypeRepo.AccountTypeId)),
                    ConstantProps.SavedSuccessfullyText));
            }
            catch (Exception ee)
            {
                //code to handle duplicate entry
                var isDuplicate = CustomValidations.DuplicateError(ee);
                if (isDuplicate != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, isDuplicate);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Create"));
            }
        }

        // PUT api/AccountType/5
        [HttpPut(Name = "UpdateAccountType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccountType([FromBody] AccountTypeDto accountType)
        {
            try
            {
                if (CustomValidations.NullCheckResponseObject(accountType) != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.NullCheckResponseObject(accountType));
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.InvalidModelResponseObject(accountType));
                }
                if (await _genericRepository.GetByIdAsync(accountType.AccountTypeId) == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, CustomValidations.NullCheckResponseObject(null));
                }
                var AccountTypeRepo = _mapper.Map<AccountType>(accountType);
                _genericRepository.UpdateRecord(AccountTypeRepo);
                if (!await _unitOfWork.CompleteAsync())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.BadRequest("Updating", "AccountType", AccountTypeRepo.AccountTypeId));
                }
                return StatusCode(StatusCodes.Status200OK, CustomValidations.SuccessOrErrorReponseType(
                    "success",
                    _mapper.Map<AccountTypeDto>(await _genericRepository.GetByIdAsync(AccountTypeRepo.AccountTypeId)),
                    ConstantProps.SavedSuccessfullyText));
            }
            catch (Exception ee)
            {
                var isDuplicate = CustomValidations.DuplicateError(ee);
                if (isDuplicate != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, isDuplicate);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Update"));
            }
        }

        /// <summary>
        /// DELETE api/AccountType/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteAccountType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            try
            {
                var entity = await _genericRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    _genericRepository.DeleteRecord(entity);
                    if (!await _unitOfWork.CompleteAsync())
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, CustomValidations.SuccessOrErrorReponseType("error", id, ConstantProps.FailedOnSave("Deleting", "AccountType")));
                    }
                    return StatusCode(StatusCodes.Status200OK, CustomValidations.SuccessOrErrorReponseType("success", _mapper.Map<AccountTypeDto>(entity), ConstantProps.DeletedSuccessfullyText));
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
