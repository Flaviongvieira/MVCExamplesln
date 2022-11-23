using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MVCExample.Models;

namespace MVCExample.Repository
{
    public class MockDB : IRepository
    {
        // create a list in lieu of DB
        private static List<Match> Matches = new List<Match>()
        {
            new Match()
            {
                MatchId = 1,
                MatchDate = DateTime.Now,
                OpponentTeam = "Portugal",
                MatchVenue = "Lisbon"
            }
        };

        public void AddMatch(Match m)
        {
            Matches.Add(m);
        }

        void IRepository.DeleteMatch(int ID)
        {
            var f = Matches.Find(x => x.MatchId == ID);
            if (f != null)
            {
                Matches.Remove(f);
            }
        }

        List<Match> IRepository.DisplayMatches()
        {
            return Matches;
        }
        void IRepository.EditMatch(Match m)
        {
            // find match
            var f = Matches.Find(x => x.MatchId == m.MatchId);
            if (f != null)
            {
                // edit goals for
                f.GoalsFor = m.GoalsFor;
                // edit goals against
                f.GoalsAgainst = m.GoalsAgainst;
            }
            
        }

        public Match FindMatch(int ID)
        {
            var found = Matches.FirstOrDefault(x => x.MatchId == ID);
            return found;
        }

        Stats IRepository.stats()
        {
            throw new NotImplementedException();
        }
    }
}
