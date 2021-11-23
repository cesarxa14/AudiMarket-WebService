using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
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
    [Route("/api/v1/videoproducers/{videoProducerId}/contracts")]
    public class VideoProducerContractsController
    {
        private readonly IContractsService _contractService;
        private readonly IMapper _mapper;

        public VideoProducerContractsController(IContractsService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractsResource>> GetAllByVideoProducer(int videoProducerId)
        {
            var reviews = await _contractService.ListByVProducerId(videoProducerId);
            var resources = _mapper.Map<IEnumerable<Contracts>, IEnumerable<ContractsResource>>(reviews);
            return resources;
        }
    }
}