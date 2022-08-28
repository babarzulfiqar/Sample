using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using API.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.MasterData;
using API.Helpers;
using Core.Interfaces.Generic;
using Core.Domain.MasterData;

namespace API.Controllers.MasterData
{
    [Route("api/master/[controller]")]
    public class BusinessTypeController : Controller
    {
        private readonly IGenericRepo<BusinessType> _genericRepository;
        private readonly IMapper _mapper;
        public BusinessTypeController(IGenericRepo<BusinessType> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// List all BusinessTypes, by default sorted by Description
        /// </summary>
        [HttpGet(Name = "GetBusinessTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBusinessTypes()
        {
            try
            {
                var businessTypes = await _genericRepository.ListAllAsync();
                var data = _mapper.Map<IReadOnlyList<BusinessTypeDto>>(businessTypes);
                if (data == null) return NotFound(CustomValidations.DataNotFoundResponseObject(""));
                if (data.Count <= 0) return NotFound(CustomValidations.DataNotFoundResponseObject(""));
                return Ok(CustomValidations.SuccessOrErrorReponseType("success", data, ConstantProps.dataListText));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
        /// <summary>
        /// Get BusinessType By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBusinessTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBusinessTypeById(int id)
        {
            try
            {
                var dataFromRepo = await _genericRepository.GetByIdAsync(id);
                if (dataFromRepo == null) return Json(CustomValidations.DataNotFoundResponseObject(id));
                return Ok(CustomValidations.SuccessOrErrorReponseType("success", _mapper.Map<BusinessTypeDto>(dataFromRepo), ConstantProps.DataFetchSuccess));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, CustomValidations.InternalServerResponseObject("Get"));
            }
        }
    }
}
