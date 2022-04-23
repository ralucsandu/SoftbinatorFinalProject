using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ISongsRepository
    {
        IQueryable<Song> GetSongsIQueryable();
        void CreateSong(Song song);
        void UpdateSong(Song song);
        void DeleteSong(Song song);
    }
}
