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
    [ApiController]
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
        public async Task<IActionResult> PostPayMethod([FromBody] SavePayMethodResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var payMethod = _mapper.Map<SavePayMethodResource, PayMethod>(resource);
            var result = await _payMethodService.SavePayMethod(payMethod);

            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(PayMethodResource);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayMethod(int id, [FromBody] SavePayMethodResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var payMethod = _mapper.Map<SavePayMethodResource, PayMethod>(resource);
            var result = await _payMethodService.UpdatePayMethod(id, payMethod);


            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(payMethodResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayMethod(int id)
        {
            var result = await _payMethodService.RemovePayMethod(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var payMethodResource = _mapper.Map<PayMethod, PayMethodResource>(result.Resource);
            return Ok(payMethodResource);
        }
    }
}
