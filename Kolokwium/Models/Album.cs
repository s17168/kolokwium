using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlbum { get; set; }
        [MaxLength(30)]
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        [ForeignKey("IdMusicLabel")]
        public virtual MusicLabel MusicLabel {get; set;}

        public virtual ICollection<Track> Track { get; set; }
    }
}
