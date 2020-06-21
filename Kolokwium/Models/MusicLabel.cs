using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MusicLabel
    {
        public MusicLabel()
        {
            Album = new HashSet<Album>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusicLabel { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
