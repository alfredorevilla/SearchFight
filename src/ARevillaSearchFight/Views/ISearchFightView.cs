using ARevillaSearchFight.Views.Models;
using System;

namespace ARevillaSearchFight.Views
{
    public interface ISearchFightView
    {
        event EventHandler<SearchAndFightArgs> SearchAndFight;

        void RenderMessage(string message);

        void RenderError(string message);

        void RenderWarningList(string titleOrCategory, string[] items);

        void RenderSearchAndFightData(SearchAndFightModel model);
    }
}