using Microsoft.EntityFrameworkCore;
using MVCExample.Models;

namespace MVCExample.Repository
{
    public class MatchContext: DbContext
    {
        // creating the link between our model/class and DB
        public DbSet<Match> Matches { get; set; }

        // Configuration (copied over from prev projs)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string
            string connectionstr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MatchDB_Repo;Integrated Security=SSPI;AttachDBFilename=d:\db\MatchDB_Repo.mdf";

            //We want to use sql server (with out defined connection string)
            optionsBuilder.UseSqlServer(connectionstr);
            //optionsBuilder.UseInMemoryDatabase("someDB");
        }
    }
}
