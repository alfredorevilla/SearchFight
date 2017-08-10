using SearchFight.Views.Models;

namespace SearchFight.Views
{
    public interface ISearchFightView
    {
        void RenderError(string message);

        void RenderMessage(string message);

        void RenderSearchAndFightData(SearchAndFightModel model);

        void RenderWarningList(string titleOrCategory, string[] items);
    }
}