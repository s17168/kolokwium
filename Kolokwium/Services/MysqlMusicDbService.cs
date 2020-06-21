using Kolokwium.DTOs.Requests;
using Kolokwium.DTOs.Responses;
using Kolokwium.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class MysqlMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;

        public MysqlMusicDbService(MusicDbContext context)
        {
            _context = context;
        }

        public MusicianResponseDto GetMusicianInfo(int id)
        {
            Musician musician = _context.Musician.Where(x => x.IdMusician.Equals(id)).FirstOrDefault();
            if (musician == null)
            {
                throw new Exception("Muzyk o podanym id nie istnieje");
            }

            List<MusicianTrack> muzTracks = _context.MusicianTrack.Where(x => x.IdMusician.Equals(musician.IdMusician)).ToList();
            if (muzTracks == null || muzTracks.Count == 0)
            {
                return new MusicianResponseDto
                {
                    FirstName = musician.FirstName,
                    LastName = musician.LastName,
                    IdMusician = musician.IdMusician,
                    NickName = musician.NickName,
                    Tracks = null
                };
            }

            List<Track> tracks = new List<Track>();
            muzTracks.ForEach(tr =>
            {
                int id = tr.IdTrack;
                Track track = _context.Track.Where(x => x.IdTrack == id).FirstOrDefault();
                if (track != null)
                {
                    tracks.Add(track);
                }
            });

            return new MusicianResponseDto
            {
                FirstName = musician.FirstName,
                LastName = musician.LastName,
                IdMusician = musician.IdMusician,
                NickName = musician.NickName,
                Tracks = tracks
            };
        }

        public void AddMusician(MusicianRequestDto musicianRequestDto)
        {
            List<TrackDto> tracksDto = musicianRequestDto.tracksDto;
            List<Track> musianTracks = new List<Track>();

            // create new tracks if they dont exist
            if (tracksDto != null)
            {
                tracksDto.ForEach(tr =>
                {
                    Track dbTrack = _context.Track.Where(x => x.TrackName.Equals(tr.trackName)).FirstOrDefault();
                    if (dbTrack == null)
                    {
                        Track newTrack = new Track {TrackName=tr.trackName, Duration=tr.duration};
                        musianTracks.Add(newTrack);
                        _context.Add(newTrack);
                    } else
                    {
                        musianTracks.Add(dbTrack);
                    }
                });
            }

            Musician newMusician = new Musician(){FirstName = musicianRequestDto.firstName, LastName = musicianRequestDto.lastName, NickName = musicianRequestDto.nickName};
            _context.Add(newMusician);

            musianTracks.ForEach(tr => {
                var muzTrack = new MusicianTrack() { IdTrack=tr.IdTrack, IdMusician=newMusician.IdMusician};
                _context.Add(muzTrack);
            });

            _context.SaveChanges();
        }

    }
}
