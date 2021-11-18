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
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        private readonly IMapper _mapper;

        public VouchersController(IVoucherService voucherService, IMapper mapper)
        {
            _voucherService = voucherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VoucherResource>> GetAllAsync()
        {
            var vouchers = await _voucherService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Voucher>, IEnumerable<VoucherResource>>(vouchers);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVoucherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveVoucherResource, Voucher>(resource);
            var result = await _voucherService.SaveAsync(voucher);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Voucher, VoucherResource>(result.Resource);
            return Ok(voucherResource);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVoucherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveVoucherResource, Voucher>(resource);
            var result = await _voucherService.UpdateAsync(id, voucher);

            if (!result.Success)
                return BadRequest(result.Message);

            var voucherResource = _mapper.Map<Voucher, VoucherResource>(result.Resource);
            return Ok(voucherResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _voucherService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Voucher, VoucherResource>(result.Resource);
            return Ok(voucherResource);

        }
    }
}
