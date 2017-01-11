using ARevillaSearchFight.Models;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Presenters
{
    public class SearchFightPresenter
    {
        public SearchFightPresenter(ISearchFightView view, ISearchFightModel model)
        {
            this.View = view;
            this.Model = model;
        }

        private void View_SearchAndFight(object sender, SearchAndFightArgs e)
        {
            this.SearchAndFight(e.Terms);
        }

        public void SearchAndFight(string[] terms)
        {
            string[] validationErrors;
            if (!this.Model.TryValidateTerms(terms: terms, validationErrors: out validationErrors))
            {
                this.View.RenderWarningList(titleOrCategory: "Validation errors", items: validationErrors);
                return;
            }
            this.View.RenderSearchAndFightData(data: new Views.Models.SearchAndFightData
            {
                SearchResults = this.Model.GetTermSearchResults(terms: terms),
                WinnerTerms = this.Model.GetWinnersTermsPerSearchEngine(terms: terms),
                OverallWinnerTerm = this.Model.GetOverallWinnerTerm(terms: terms),
            });
        }

        public ISearchFightView View { get; }
        public ISearchFightModel Model { get; }
    }
}



