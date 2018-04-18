using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

namespace Bocce
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                if (Environment.GetEnvironmentVariable("SEED") != null)
                {
                    db.Players.Add(new Player
                    {
                        FullName = "Doctor Deville",
                        NickName = "Doc",
                        Number = 42,
                        ThrowingArm = "Ambidextrous" //you're welcome

                    });
                    db.Players.Add(new Player
                    {
                        FullName = "Turtle Face",  //he's a turtle, he's a face
                        NickName = "Turtle Face",
                        Number = 8,
                        ThrowingArm = "IsLeft"
                    });
                    db.SaveChanges();
                    db.Teams.Add(new Team
                    {
                        Mascot = "Cats",
                        Color = "Purple"
                    });
                    db.Teams.Add(new Team
                    {
                        Mascot = "Dogs",
                        Color = "Red"
                    });
                    db.SaveChanges();
                    var dogs = db.Teams.Include(t => t.Players).First(f => f.Mascot == "Dogs");
                    var player = db.Players.First(p => p.FullName == "Doctor Deville");
                    dogs.Players.Add(player);

                    var cats = db.Teams.Include(c => c.Players).First(v => v.Mascot == "Cats");
                    var player2 = db.Players.First(x => x.FullName == "Turtle Face");
                    cats.Players.Add(player2);
                    db.SaveChanges();

                    db.Games.Add(new Game
                    {
                        HomeTeam = dogs,
                        AwayTeam = cats,
                        HomeScore = 42,
                        AwayScore = 8,
                        DateHappened = DateTime.Today,
                        Notes = "One ring to rule them all, one ring to find them, one ring to bring them all and in the darkness bind them!"
                    });
                    db.Games.Add(new Game
                    {
                        HomeTeam = cats,
                        AwayTeam = dogs,
                        DateHappened = DateTime.MaxValue,
                        Notes = "The dark web clouds everything. Impossible to see the future is."
                    });
                    db.SaveChanges();
                }
                var scores = db.Teams.Include(s => s.HomeGames).Include(s => s.AwayGames).Where(w => db.Games.Any(l => l.DateHappened < DateTime.Now));
                foreach (var score in scores)
                {
                    int wins = score.HomeGames.Where(g => g.HomeScore > 0 && g.HomeScore > g.AwayScore).Count();
                    int awayWins = score.AwayGames.Where(g => g.AwayScore > 0 && g.AwayScore > g.HomeScore).Count();
                    int homeCount = score.HomeGames.Where(g => g.DateHappened < DateTime.Now).Count();
                    int awayCount = score.AwayGames.Where(g => g.DateHappened < DateTime.Now).Count();

                    Console.WriteLine("Team {0}: {1} wins, {2} loses", score.Mascot, wins + awayWins, homeCount + awayCount - wins - awayWins);
                    

                }
                var allPlayers = db.Players.Include(f => f.Team);
                foreach(var player in allPlayers)
                {
                    Console.WriteLine("{0}-{1}", player.FullName, player.Team.Mascot);
                }

                var allFutureGames = db.Games.Where(g => g.DateHappened > DateTime.Now);
                foreach(var game in allFutureGames)
                {
                    Console.WriteLine("{0}", game.DateHappened);
                }
                var allPastGames = db.Games.Where(y => y.DateHappened < DateTime.Now);
                foreach(var game in allPastGames)
                {
                    Console.WriteLine("{0}", game.DateHappened);
                }
            }
            Console.WriteLine("Hi mom.");
            Console.ReadLine();
        }
    }
}
