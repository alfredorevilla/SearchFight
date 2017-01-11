using FluentAssertions;
using ARevillaSearchFight.Models;
using ARevillaSearchFight.Presenters;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Views.Models;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Tests
{
    public class SearchFightPresenterTests
    {
        SearchFightPresenter _presenter;
        ISearchFightView _view;
        ISearchFightModel _model;

        public SearchFightPresenterTests()
        {
            _view = A.Fake<ISearchFightView>();            
            _model = A.Fake<ISearchFightModel>();
            _presenter = new SearchFightPresenter(_view, _model);
        }

        public void Test1()
        {

            A.CallTo(() => _model.GetTermSearchResults(new string[] { })).WithAnyArguments().Returns(new []
            {
                new TermSearchResult
                {
                    Count = 100,
                    SearchEngineName = "engine1",
                    Term = "java"
                },
                new TermSearchResult
                {
                    Count = 150,
                    SearchEngineName = "engine2",
                    Term = "java"
                },
                new TermSearchResult
                {
                    Count = 100,
                    SearchEngineName = ".net",
                    Term = "java"
                },
                new TermSearchResult
                {
                    Count = 150,
                    SearchEngineName = ".net",
                    Term = "java"
                }
            });

            var terms = new[] { "java", ".net" };
            _presenter.SearchAndFight(terms);

            //  assert
            //A.CallTo(() => _view.RenderSearchAndFightData(null)).WhenArgumentsMatch()
            
        }
    }
}
