namespace ORevillaSearchFight.Views.Models
{
    /// <summary>
    /// Extensive model
    /// </summary>
    public class SearchAndFightModel
    {
        public string OverallWinnerTerm { get; set; }

        public TermSearchResult[] SearchResults { get; set; }

        public TermSearchResult[] WinnerTerms { get; set; }
    }
}