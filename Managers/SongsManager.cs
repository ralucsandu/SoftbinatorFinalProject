using FinalProject.Entities;
using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public class SongsManager : ISongsManager
    {
        private readonly ISongsRepository songsRepository;
        public SongsManager(ISongsRepository songsRepository)
        {
            this.songsRepository = songsRepository;
        }
        public List<SongModel> GetSongs()
        {
            var songs = songsRepository.GetSongsIQueryable()
                .Select(x => new SongModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    MusicalInstrument = x.MusicalInstrument
                })
                .ToList();
            return songs;
        }
        public List<int> GetSongIdsList()
        {
            var songs = songsRepository.GetSongsIQueryable();
            var idList = songs.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Song GetSongById(int id)
        {
            var song = songsRepository.GetSongsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return song;
        }

        public void CreateSong(SongModel songModel)
        {
            var newSong = new Song
            {
                Name = songModel.Name,
                MusicalInstrument = songModel.MusicalInstrument
            };

            songsRepository.CreateSong(newSong);
        }

        public void UpdateSong(SongModel songModel)
        {
            var song = GetSongById(songModel.Id);
            song.Name = songModel.Name;
            song.MusicalInstrument = songModel.MusicalInstrument;
            songsRepository.UpdateSong(song);
        }

        public void DeleteSong(int Id)
        {
            var song = GetSongById(Id);
            songsRepository.DeleteSong(song);
        }

    }
}
