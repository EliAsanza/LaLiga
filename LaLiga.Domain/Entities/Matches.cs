namespace LaLiga.Domain.Entities
{
    public class Matches
    {
        public int MatchesId { get; set; }
        public DateTime MatchDate { get; set; }
        public int LocalTeamId { get; set; }
        public int VisitorTeamId { get; set; }
        public int LocalScore { get; set; }
        public int VisitorScore { get; set; }
    }
}