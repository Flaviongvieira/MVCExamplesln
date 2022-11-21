using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace MVCExample.Models
{
    public class Match
    {
        // Match ID
        public int MatchId { get; set; }

        // Match Date
        [Display(Name = "Match Date")]
        public DateTime MatchDate { get; set; }
        [Required]
        [StringLength( maximumLength:100, MinimumLength = 2)]

        // Match Venue
        [Display(Name = "Match Venue")]
        public string MatchVenue { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]

        // Opponent Team
        [Display(Name = "Opponent Team")]
        public string OpponentTeam { get; set; }
        [Range(0, 100, ErrorMessage = "Max number of goals allowed is 100")]

        // Goals For
        [Display(Name = "Goals For")]
        public int GoalsFor { get; set; }

        // Goals Against
        [Display(Name = "Goals Against")]
        [Range(0, 100, ErrorMessage = "Max number of goals allowed is 100")]
        public int GoalsAgainst { get; set; }

        // Constructor
        public Match()
        {
            this.MatchVenue = "";
            this.OpponentTeam = "";
        }
    }
}
