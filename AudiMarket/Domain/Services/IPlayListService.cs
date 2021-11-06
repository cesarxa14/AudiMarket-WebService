using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IPlayListService
    {
        Task<IEnumerable<PlayList>> GetAll();
        Task<PlayListResponse> SaveMusicProducer(PlayList playList);

        Task<PlayListResponse> UpdatePlayList(int id, PlayList playList);

        Task<PlayListResponse> DeletePlayList(int id);
    }
}