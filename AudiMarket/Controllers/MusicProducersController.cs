using AudiMarket.Attributes;
using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
using AudiMarket.Domain.Services.Communications;
using AudiMarket.Extensions;
using AudiMarket.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Controllers
{

    [Authorize]
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MusicProducersController : ControllerBase
    {
        private readonly IMusicProducerService _musicProducerService;
        private readonly IMapper _mapper;

        public MusicProducersController(IMusicProducerService musicProducerService, IMapper mapper)
        {
            _musicProducerService = musicProducerService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<MusicProducerResource>> GetAllMusicProducer()
        {
            var musicProducers = await _musicProducerService.GetAll();
            var resources = _mapper.Map<IEnumerable<MusicProducer>, IEnumerable<MusicProducerResource>>(musicProducers);
            return resources;
        }

        [AllowAnonymous]
        [HttpPost]
        
        [SwaggerOperation(
            Summary = "Create a music producer",
            Description = "Create a new music producer",
            Tags = new[] { "Music Producers" })
        ]
        public async Task<IActionResult> PostMusicProducer([FromBody] SaveMusicProducerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var musicProducer = _mapper.Map<SaveMusicProducerResource, MusicProducer>(resource);
            var result = await _musicProducerService.SaveMusicProducer(musicProducer);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicProducerResource = _mapper.Map<MusicProducer, MusicProducerResource>(result.Resource);
            return Ok(musicProducerResource);

        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a music producer",
            Description = "Update music producer's data",
            Tags = new[] { "Music Producers" })
        ]
        public async Task<IActionResult> PutMusicProducer([SwaggerParameter("Music Producer ID")] int id, [FromBody] SaveMusicProducerResource resource)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var musicProducer = _mapper.Map<SaveMusicProducerResource, MusicProducer>(resource);
            var result = await _musicProducerService.UpdateMusicProducer(id, musicProducer);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicProducerResource = _mapper.Map<MusicProducer, MusicProducerResource>(result.Resource);
            return Ok(musicProducerResource);

        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _musicProducerService.DeleteMusicProducer(id);
 
            if (!result.Success)
                return BadRequest(result.Message);

            var musicProducerResource = _mapper.Map<MusicProducer, MusicProducerResource>(result.Resource);
            return Ok(musicProducerResource);

        }

        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _musicProducerService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _musicProducerService.Register(request);
            return Ok(new { message = "Registration succesful" });
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _musicProducerService.GetById(id);
            var resource = _mapper.Map<MusicProducer, MusicProducerResource>(user);
            return Ok(resource);
        }
    }
}
