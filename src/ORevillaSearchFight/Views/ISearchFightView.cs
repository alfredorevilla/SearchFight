using ORevillaSearchFight.Views.Models;

namespace ORevillaSearchFight.Views
{
    public interface ISearchFightView
    {
        void RenderError(string message);

        void RenderMessage(string message);

        void RenderSearchAndFightData(SearchAndFightModel model);

        void RenderWarningList(string titleOrCategory, string[] items);
    }
}