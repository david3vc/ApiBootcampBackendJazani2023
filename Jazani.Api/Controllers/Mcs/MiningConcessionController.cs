﻿using Jazani.Api.Exceptions;
using Jazani.Application.Mcs.Dtos.MiningConcessions;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    public class MiningConcessionController : Controller
    {
        private readonly IMiningConcessionService _miningConcessionService;

        public MiningConcessionController(IMiningConcessionService miningConcessionService)
        {
            _miningConcessionService = miningConcessionService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<MiningConcessionDto>> Get()
        {
            return await _miningConcessionService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Get(int id)
        {
            var response = await _miningConcessionService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConcessionDto>>> Post([FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            var response = await _miningConcessionService.CreateAsync(miningConcessionSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<MiningConcessionDto> Put(int id, [FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionService.EditAsync(id, miningConcessionSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<MiningConcessionDto> Delete(int id)
        {
            return await _miningConcessionService.DisabledAsync(id);
        }
    }
}
