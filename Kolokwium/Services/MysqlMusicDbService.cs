using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
