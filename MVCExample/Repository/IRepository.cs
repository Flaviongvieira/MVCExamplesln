using MVCExample.Models;

namespace MVCExample.Repository
{
    public interface IRepository
    {
        // Add a match to DB
        public void AddMatch(Match m);

        // Edit the match info and save in DB (results only)
        public void EditMatch(Match m);

        // Delete a match from DB
        public void DeleteMatch(Match m);

        // Display all Matches
        List<Match> DisplayMatches();

        // Find Match by ID
        public Match FindMatch(int ID);

        // Display Stats
        public void DisplayStats();

    }
}
