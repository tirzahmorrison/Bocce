using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bocce
{
    class DatabaseContext: DbContext
    {
       public DbSet<Player> Players { get; set; }
       public DbSet<Team> Teams { get; set; }
       public DbSet<Game> Games { get; set; }

    }
}
