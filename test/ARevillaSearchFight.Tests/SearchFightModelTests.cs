using ARevillaSearchFight.Models.Implementations;
using ARevillaSearchFight.Search;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ARevillaSearchFight.Tests
{
    public class SearchFightModelTests
    {
        ISearchEngine _engine1;
        ISearchEngine _engine2;
        ISearchEngine _engine3;
        private SearchFightModel _model;
        public SearchFightModelTests()
        {
            //  arrange
            _engine1 = A.Fake<ISearchEngine>(options => options.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine1), "")));
            _engine2 = A.Fake<ISearchEngine>(options => options.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine2), "")));
            _engine3 = A.Fake<ISearchEngine>(options => options.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine3), "")));

            A.CallTo(() => _engine1.GetSearchTotalCount(".net")).Returns(100);
            A.CallTo(() => _engine1.GetSearchTotalCount("java")).Returns(55);
            A.CallTo(() => _engine2.GetSearchTotalCount(".net")).Returns(150);
            A.CallTo(() => _engine2.GetSearchTotalCount("java")).Returns(23);
            A.CallTo(() => _engine3.GetSearchTotalCount(".net")).Returns(78);
            A.CallTo(() => _engine3.GetSearchTotalCount("java")).Returns(455);
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });
        }

        [Fact]
        public void GetTermSearchResults()
        {
            //  arrange
            var terms = new[] { ".net", "java" };

            //  act
            var results = _model.GetTermSearchResults(terms);

            //  assert
            results.Count().Should().Be(6);
            results.Select(o => o.SearchEngineName).Distinct().Count().Should().Be(3);
            results.Select(o => o.Term).Distinct().Count().Should().Be(2);
            results.Select(o => o.Count).Sum().Should().Be(100 + 55 + 150 + 23 + 78 + 455);
        }
    }
}