using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
using AudiMarket.Resources;
using AudiMarket.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AuthController
    {
        private readonly IMusicProducerService _musicProducerService;
        private readonly IMapper _mapper;

        public AuthController(IMusicProducerService musicProducerService, IMapper mapper)
        {
            _musicProducerService = musicProducerService;
            _mapper = mapper;
        }
        /*
        [HttpPost]
        [SwaggerOperation(
            Summary = "Login",
            Description = "Create a new producer",
            Tags = new[] { "Login Producers" })
        ]
        public async Task<IActionResult> login([SwaggerParameter("Type User")] string typeUser, [FromBody] MusicProducerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if(typeUser == 'music')
            {
               var existUsername = 
            }
            var musicProducer = _mapper.Map<MusicProducerResource, MusicProducer>(resource);
            var result = await _musicProducerService.SaveMusicProducer(musicProducer);

            if (!result.Success)
                return BadRequest(result.Message);

            var musicProducerResource = _mapper.Map<MusicProducer, MusicProducerResource>(result.Resource);
            return Ok(musicProducerResource);

        }*/
    }
}
