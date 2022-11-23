using MVCExample.Models;

namespace MVCExample.Repository
{
    public class RealDB : IRepository
    {
        // Initiate the DBContext when we use this repository
        MatchContext ct;
        public RealDB()
        {
            ct = new MatchContext();
        }

        // Functions inherited from IRepository
        public void AddMatch(Match m)
        {
            ct.Matches.Add(m);
            ct.SaveChanges();
        }

        public void DeleteMatch(int ID)
        {
            // find match
            var f = ct.Matches.FirstOrDefault(x => x.MatchId == ID);
            if (f != null)
            {
                ct.Matches.Remove(f);
                ct.SaveChanges();
            }
            
        }

        public List<Match> DisplayMatches()
        {
            return ct.Matches.ToList();
        }

        public void DisplayStats()
        {
            throw new NotImplementedException();
        }

        public void EditMatch(Match m)
        {
            // find match
            var f = ct.Matches.FirstOrDefault(x => x.MatchId == m.MatchId);
            if (f != null)
            {
                // edit goals for
                f.GoalsFor = m.GoalsFor;
                // edit goals against
                f.GoalsAgainst = m.GoalsAgainst;
                ct.SaveChanges();
            }
        }

        public Match FindMatch(int ID)
        {
            var found = ct.Matches.FirstOrDefault(x => x.MatchId == ID);
            return found;
        }

        (int wons, int lost, int draw, int points, int goaldif) IRepository.stats()
        {
            var played = ct.Matches.Where(x => x.MatchDate < DateTime.Today.Date);
            var wons = played.Where(x => (x.GoalsAgainst < x.GoalsFor)).ToList().Count();
            var lost = played.Where(x => (x.GoalsAgainst > x.GoalsFor)).ToList().Count();
            var draw = played.Where(x => (x.GoalsAgainst == x.GoalsFor)).ToList().Count();

            var points = wons * 3 + draw * 1;

            var goaldif = 0;
            int gf = 0;
            int ga = 0;
            foreach (var g in played)
            {
                gf += g.GoalsFor;
                ga += g.GoalsAgainst;
                goaldif = gf - ga;
            }

            return (wons, lost,draw,points,goaldif);
        }
    }
}
