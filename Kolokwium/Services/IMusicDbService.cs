using Kolokwium.DTOs.Requests;
using Kolokwium.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IMusicDbService
    {
        public MusicianResponseDto GetMusicianInfo(int id);
        public void AddMusician(MusicianRequestDto musicianRequestDto);
    }
}
