using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Track
    {
        public Track()
        {
            MusicianTrack = new HashSet<MusicianTrack>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTrack { get; set; }
        [MaxLength(20)]
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

        [ForeignKey("IdMusicAlbum")]
        public virtual Album Album { get; set; }

        public virtual ICollection<MusicianTrack> MusicianTrack { get; set; }

    }
}
