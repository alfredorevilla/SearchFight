using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Views.Models;

namespace ARevillaSearchFight.Views.Implementations
{
    public class SearchFightConsoleView : ISearchFightView
    {
        public event EventHandler<SearchAndFightArgs> SearchAndFight;

        public void RenderError(string message)
        {
            throw new NotImplementedException();
        }

        public void RenderMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void RenderSearchAndFightData(SearchAndFightData data)
        {
            throw new NotImplementedException();
        }

        public void RenderWarningList(string titleOrCategory, string[] items)
        {
            throw new NotImplementedException();
        }
    }
}
