namespace LaLiga.Domain.Models.Matches
{
    public class CreatedMatchesViewModel
    {
        public DateTime MatchDate { get; set; }
        public int LocalTeamId { get; set; }
        public int VisitorTeamId { get; set; }
        public int LocalScore { get; set; }
        public int VisitorScore { get; set; }

    }
}
