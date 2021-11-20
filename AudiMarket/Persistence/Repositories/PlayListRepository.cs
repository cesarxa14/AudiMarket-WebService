using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Persistence.Repositories
{
    public class PlayListRepository : BaseRepository, IPlayListRepository
    {
        public PlayListRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PlayList playList)
        {
            await _context.PlayLists.AddAsync(playList);
        }

        public async Task<PlayList> FindById(int id)
        {
            return await _context.PlayLists.Include(p => p.MusicProducer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PlayList>> FindByMusicProducerId(int MProducerId)
        {
            return await _context.PlayLists.
                Where(p => p.MusicProducerId == MProducerId)
                .Include(p => p.MusicProducer).ToListAsync();
        }

        public async Task<IEnumerable<PlayList>> GetAll()
        {
            //return await _context.PlayLists.Include(p => p.MusicProducer).ToListAsync();
            return await _context.PlayLists.ToListAsync();
        }

        public async Task<IEnumerable<PlayList>> ListAsync()
        {
            return await _context.PlayLists.ToListAsync();
        }

        public void Remove(PlayList playList)
        {
            _context.PlayLists.Remove(playList);
        }

        public void Update(PlayList playList)
        {
            _context.PlayLists.Update(playList);
        }
    }
}