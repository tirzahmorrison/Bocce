using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocce
{
    class Team
    {
        public int ID { get; set; }
        public string Mascot { get; set; }
        public string Color { get; set; }

        public virtual List<Player> Players { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual ICollection<Game> HomeGames { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual ICollection<Game> AwayGames { get; set; }

    }
}
