namespace ARevillaSearchFight.Views.Models
{
    /// <summary>
    /// Extensive model
    /// </summary>
    public class SearchAndFightData
    {
        public string OverallWinnerTerm { get; set; }

        public ResultCountPerTermPerEngine[] TotalResultsPerTermPerEngine { get; set; }

        public WinnerTermPerEngine[] WinnerTermPerSearchEngine { get; set; }

    }
}