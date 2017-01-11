namespace ARevillaSearchFight.Views.Models
{
    /// <summary>
    /// Extensive model
    /// </summary>
    public class SearchAndFightData
    {
        public string OverallWinnerTerm { get; set; }

        public TermSearchResult[] SearchResults { get; set; }

        public TermSearchResult[] WinnerTerms { get; set; }

    }
}