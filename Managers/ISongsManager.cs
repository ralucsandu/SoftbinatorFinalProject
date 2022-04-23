using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface ISongsManager
    {
        List<SongModel> GetSongs();
        List<int> GetSongIdsList();
        Song GetSongById(int id);
        void CreateSong(SongModel obiectModel);
        void UpdateSong(SongModel obiectModel);
        void DeleteSong(int SongId);

    }
}
