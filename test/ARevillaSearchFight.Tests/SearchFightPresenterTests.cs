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
using Xunit;

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

        [Fact]
        public void SearchAndFightTest()
        {
            //  arrange
            A.CallTo(() => _model.GetTermSearchResults(new string[] { })).WithAnyArguments().Returns(new[]
            {
                new ModelTermSearchResult
                {
                    Count = 100,
                    SearchEngineName = "engine1",
                    Term = "java"
                },
                new ModelTermSearchResult
                {
                    Count = 150,
                    SearchEngineName = "engine2",
                    Term = "java"
                },
                new ModelTermSearchResult
                {
                    Count = 130,
                    SearchEngineName = "engine1",
                    Term = ".net"
                },
                new ModelTermSearchResult
                {
                    Count = 170,
                    SearchEngineName = "engine2",
                    Term = ".net"
                }
            });

            var terms = new[] { "java", ".net" };

            //  act
            _presenter.SearchAndFight(terms);

            //  assert
            A.CallTo(() => _view.RenderSearchAndFightData(null)).WithAnyArguments()
                .Invokes(fake =>
                {
                    var model = fake.GetArgument<SearchAndFightModel>(0);
                    model.OverallWinnerTerm.Should().Be(".net");
                    model.SearchResults.Count().Should().Be(4);
                    model.SearchResults.Select(o => o.SearchEngineName).Distinct().Count().Should().Be(2);
                    model.SearchResults.Select(o => o.Term).Distinct().Count().Should().Be(2);
                    model.WinnerTerms.Count().Should().Be(2);
                    model.WinnerTerms.Select(o => o.Term).Distinct().Count().Should().Be(2);
                    model.WinnerTerms.Select(o => o.Term).Distinct().Count().Should().Be(2);
                });
        }
    }
}
