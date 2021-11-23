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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetAllAsync()
        {
            var reviews = await _reviewService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostReview([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

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
            if(!ModelState.IsValid)
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
        }
        /*
        [HttpGet("{musicProducerID}")]
        public async Task<IEnumerable<ReviewResource>> GetByIdMProducer(int id)
        {
            var revs = await _reviewService.ListByMProducerId(id);
            var resource = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(revs);
            return resource;
        }*/
    }
}
