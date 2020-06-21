using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MusicDbContext : DbContext
    {

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Musician> Musician { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTrack { get; set; }
        public virtual DbSet<MusicLabel> MusicLabel { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        public MusicDbContext()
        {

        }

        public MusicDbContext(DbContextOptions options)
            : base(options)
        {

        }

    }
}
