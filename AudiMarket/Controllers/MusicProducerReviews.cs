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
    [Route("/api/v1/musicproducers/{musicProducerId}/reviews")]
    public class MusicProducerReviews
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public MusicProducerReviews(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetAllByMusicProducer(int musicProducerId)
        {
            var reviews = await _reviewService.ListByMProducerId(musicProducerId);
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }
    }
}