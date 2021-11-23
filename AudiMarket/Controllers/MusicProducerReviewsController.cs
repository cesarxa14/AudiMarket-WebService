using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
using AudiMarket.Resources;
using AudiMarket.Extensions;
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
    public class MusicProducerReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public MusicProducerReviewsController(IReviewService reviewService, IMapper mapper)
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
        /*
        [HttpPost]
        public async Task<IActionResult> PostMusicProducer([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            //if(!ModelState)

            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.SaveReview(review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, [FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.UpdateReview(id, review);


            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.RemoveReview(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }*/
    }
}
