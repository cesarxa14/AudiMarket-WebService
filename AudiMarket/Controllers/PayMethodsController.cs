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
    public class PayMethodsController : ControllerBase
    {
        private readonly IPayMethodService _payMethodService;
        private readonly IMapper _mapper;

        public PayMethodsController(IPayMethodService payMethodService, IMapper mapper)
        {
            _payMethodService = payMethodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PayMethodResource>> GetAllAsync()
        {
            var payMethods = await _payMethodService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PayMethod>, IEnumerable<PayMethodResource>>(payMethods);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePayMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var payMethod = _mapper.Map<SavePayMethodResource, PayMethod>(resource);
            var result = await _payMethodService.SaveAsync(payMethod);

            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(payMethodResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePayMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var payMethod = _mapper.Map<SavePayMethodResource, PayMethod>(resource);
            var result = await _payMethodService.UpdateAsync(id, payMethod);

            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(payMethodResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _payMethodService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(payMethodResource);

        }


    }
}