using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocce
{
    class Game
    {
        public int ID { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime DateHappened { get; set; }
        public string Notes { get; set; }

        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

    }
}
