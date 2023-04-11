namespace LaLiga.Domain.Models.Matches
{
    public class MatchesViewModel
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public string LocalTeam { get; set; }
        public string VisitorTeam { get; set; }
        public int LocalScore { get; set; }
        public int VisitorScore { get; set; }
        public string Winner { get; set; }

    }
}