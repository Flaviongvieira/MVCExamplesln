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

        public void DeleteMatch(Match m)
        {
            ct.Matches.Remove(m);
            ct.SaveChanges();
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
    }
}
