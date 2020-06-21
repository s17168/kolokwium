using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {

        }

        public MusicDbContext(DbContextOptions options)
            : base(options)
        {

        }

    }
}
