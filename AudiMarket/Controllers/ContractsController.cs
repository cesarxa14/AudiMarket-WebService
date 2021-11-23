using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
using AudiMarket.Extensions;
using AudiMarket.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Controllers
{
    [Route("/api/v1/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractsService _contractsService;
        private readonly IMapper _mapper;

        public ContractsController(IContractsService contractService, IMapper mapper)
        {
            _contractsService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractsResource>> GetAllAsync()
        {
            var contracts = await _contractsService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contracts>, IEnumerable<ContractsResource>>(contracts);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveContractsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveContractsResource, Message>(resource);
            var result = await _contractsService.SaveAsync(contract);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractsResource = _mapper.Map<Contracts, ContractsResource>(result.Resource);
            return Ok(contractsResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContractsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveMessageResource, Contracts>(resource);
            var result = await _contractsService.UpdateAsync(id, contract);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractResource = _mapper.Map<Contracts, ContractsResource>(result.Resource);
            return Ok(contractResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contractsService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractResource = _mapper.Map<Contracts, ContractsResource>(result.Resource);
            return Ok(contractResource);

        }


    }
}