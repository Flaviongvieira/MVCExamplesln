namespace MVCExample.Models
{
    public class Stats
    {
        // (Win = 3 points, Draw = 1, Lose= 0)
        // (up to the current date)
        public int Won { get; set; }

        public int Lost { get; set; }

        public int Draw { get; set; }

        public int GoalDif { get; set; }

        public int Points { get; set; }

    }
}
