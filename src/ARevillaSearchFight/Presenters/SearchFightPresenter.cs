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

            this.View.SearchAndFight += View_SearchAndFight;

        }

        private void View_SearchAndFight(object sender, SearchAndFightArgs e)
        {
            string[] validationErrors;
            if (!this.Model.ValidateTerms(terms: e.Terms, validationErrors: out validationErrors))
            {
                this.View.RenderWarningList(titleOrCategory: "Validation errors", items: validationErrors);
                return;
            }
            this.View.RenderSearchAndFightData(data: new Views.Models.SearchAndFightData
            {
                TotalResultsPerTermPerEngine = this.Model.GetResultsCountPerTermPerEngine(terms: e.Terms),
                WinnerTermPerSearchEngine = this.Model.GetWinnersTermsPerSearchEngine(terms: e.Terms),
                OverallWinnerTerm = this.Model.GetOverallWinnerTerm(terms: e.Terms),
            });
        }


        public ISearchFightView View { get; }
        public ISearchFightModel Model { get; }
    }
}



