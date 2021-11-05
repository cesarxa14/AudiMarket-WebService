
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
    [Route("/api/v1/musicproducers/{musicProducerId}/publications")]
    public class MusicProducerPublications
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public MusicProducerPublications(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PublicationResource>> GetAllByMusicProducer(int musicProducerId)
        {
            var publications = await _publicationService.ListByMProducerId(musicProducerId);
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }
    }
}
