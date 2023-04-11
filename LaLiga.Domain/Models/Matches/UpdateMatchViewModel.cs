namespace LaLiga.Domain.Models.Matches
{
    public class UpdateMatchViewModel
    {
        public int MatchesId { get; set; }
        public DateTime MatchDate { get; set; }
        public int LocalScore { get; set; }
        public int VisitorScore { get; set; }
    }
}
