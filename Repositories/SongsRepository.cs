using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class SongsRepository : ISongsRepository
    {
        private FinalProjectContext db;

        public SongsRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Song> GetSongsIQueryable()
        {
            var songs = db.Songs;
            return songs;
        }

        public void CreateSong(Song song)
        {
            db.Songs.Add(song);
            db.SaveChanges();
        }

        public void UpdateSong(Song song)
        {
            db.Songs.Update(song);
            db.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            db.Songs.Remove(song);
            db.SaveChanges();
        }

    }
}
