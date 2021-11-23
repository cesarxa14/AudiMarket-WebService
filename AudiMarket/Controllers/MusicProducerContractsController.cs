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
    [Route("/api/v1/musicproducers/{musicProducerId}/contracts")]
    public class MusicProducerContractsController
    {
        private readonly IContractsService _contractService;
        private readonly IMapper _mapper;

        public MusicProducerContractsController(IContractsService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractsResource>> GetAllByMusicProducer(int musicProducerId)
        {
            var reviews = await _contractService.ListByMProducerId(musicProducerId);
            var resources = _mapper.Map<IEnumerable<Contracts>, IEnumerable<ContractsResource>>(reviews);
            return resources;
        }
    }
}
