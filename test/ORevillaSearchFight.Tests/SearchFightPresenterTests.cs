using FluentAssertions;
using SearchFight.Models;
using SearchFight.Presenters;
using SearchFight.Views;
using SearchFight.Views.Models;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;

namespace SearchFight.Tests
{
    public class SearchFightPresenterTests
    {
        private ILoggerFactory _logger;
        private ISearchFightModel _model;
        private SearchFightPresenter _presenter;
        private ISearchFightView _view;

        public SearchFightPresenterTests()
        {
            _view = A.Fake<ISearchFightView>();
            _model = A.Fake<ISearchFightModel>();
            _logger = A.Fake<ILoggerFactory>();
            _presenter = new SearchFightPresenter(new SearchFightPresenterCtorArgs
            {
                LoggerFactory = _logger,
                View = _view,
                Model = _model,
            });
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