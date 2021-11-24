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
    public class VideoProducersController : ControllerBase
    {
        private readonly IVideoProducerService _videoProducerService;
        private readonly IMapper _mapper;

        public VideoProducersController(IVideoProducerService videoProducerService, IMapper mapper)
        {
            _videoProducerService = videoProducerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoProducerResource>> GetAllVideoProducer()
        {
            var videoProducers = await _videoProducerService.GetAll();
            var resources = _mapper.Map<IEnumerable<VideoProducer>, IEnumerable<VideoProducerResource>>(videoProducers);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostVideoProducer([FromBody] SaveVideoProducerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videoProducer = _mapper.Map<SaveVideoProducerResource, VideoProducer>(resource);
            var result = await _videoProducerService.SaveVideoProducer(videoProducer);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoProducerResource = _mapper.Map<VideoProducer, VideoProducerResource>(result.Resource);
            return Ok(videoProducerResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoProducer(int id, [FromBody] SaveVideoProducerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videoProducer = _mapper.Map<SaveVideoProducerResource, VideoProducer>(resource);
            var result = await _videoProducerService.UpdateVideoProducer(id, videoProducer);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoProducerResource = _mapper.Map<VideoProducer, VideoProducerResource>(result.Resource);
            return Ok(videoProducerResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _videoProducerService.DeleteVideoProducer(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoProducerResource = _mapper.Map<VideoProducer, VideoProducerResource>(result.Resource);
            return Ok(videoProducerResource);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _videoProducerService.GetById(id);
            var resource = _mapper.Map<VideoProducer, VideoProducerResource>(user);
            return Ok(resource);
        }
    }
}
