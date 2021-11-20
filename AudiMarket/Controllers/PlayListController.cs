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
    public class PlayListsController : ControllerBase
    {
        private readonly IPlayListService _playListService;
        private readonly IMapper _mapper;

        public PlayListsController(IPlayListService playListService, IMapper mapper)
        {
            _playListService = playListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayListResource>> GetAllAsync()
        {
            var playLists = await _playListService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PlayList>, IEnumerable<PlayListResource>>(playLists);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayList([FromBody] SavePlayListResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var playList = _mapper.Map<SavePlayListResource, PlayList>(resource);
            var result = await _playListService.SavePlayList(playList);

            if (!result.Success)
                return BadRequest(result.Message);

            var playListResource = _mapper.Map<PlayList, PlayListResource>(result.Resource);
            return Ok(playListResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, [FromBody] SavePlayListResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var playList = _mapper.Map<SavePlayListResource, PlayList>(resource);
            var result = await _playListService.UpdatePlayList(id, playList);


            if (!result.Success)
                return BadRequest(result.Message);

            var playListResource = _mapper.Map<PlayList, PlayListResource>(result.Resource);
            return Ok(playListResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            var result = await _playListService.RemovePlayList(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var playListResource = _mapper.Map<PlayList, PlayListResource>(result.Resource);
            return Ok(playListResource);
        }
    }
}
