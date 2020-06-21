using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Requests
{
    public class MusicianRequestDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickName { get; set; }

        public List<TrackDto> tracksDto { get; set; }
    }

    public class TrackDto
    {
        public string trackName { get; set; }
        public float duration{ get; set; }
    }
}
