using ARevillaSearchFight.Models;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Views.Models;
using System.Linq;

namespace ARevillaSearchFight.Presenters
{
    public class SearchFightPresenter
    {
        public SearchFightPresenter(ISearchFightView view, ISearchFightModel model)
        {
            this.View = view;
            this.Model = model;
        }

        public ISearchFightModel Model { get; }

        public ISearchFightView View { get; }

        public void SearchAndFight(string[] terms)
        {
            string[] validationErrors;
            if (!this.Model.TryValidateTerms(terms: terms, validationErrors: out validationErrors))
            {
                this.View.RenderWarningList(titleOrCategory: "Validation errors: ", items: validationErrors);
                return;
            }
            try
            {
                var modelResults = this.Model.GetTermSearchResults(terms);
                var results = modelResults.Select(o => new TermSearchResult { Count = o.Count, SearchEngineName = o.SearchEngineName, Term = o.Term }).ToArray();
                var winners = modelResults.GetWinnersTermsPerSearchEngine().Select(model => results.Single(result => result.Term == model.Term && result.SearchEngineName == model.SearchEngineName)).Select(model => new TermSearchResult
                {
                    Count = model.Count,
                    SearchEngineName = model.SearchEngineName,
                    Term = model.Term
                }).ToArray();
                this.View.RenderSearchAndFightData(new Views.Models.SearchAndFightModel
                {
                    SearchResults = results,
                    WinnerTerms = winners,
                    OverallWinnerTerm = modelResults.GetOverallWinnerTerm()
                });
            }
            catch (System.Exception e)
            {
                this.View.RenderError(e.Message);
            }
        }

        private void View_SearchAndFight(object sender, SearchAndFightArgs e)
        {
            this.SearchAndFight(e.Terms);
        }
    }
}