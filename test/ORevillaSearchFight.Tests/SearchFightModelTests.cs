using ORevillaSearchFight.Models.Implementations;
using ORevillaSearchFight.Search;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ORevillaSearchFight.Tests
{
    public class SearchFightModelTests
    {
        private ISearchEngine _engine1;
        private ISearchEngine _engine2;
        private ISearchEngine _engine3;
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
        }

        [Fact]
        public void GetTermSearchResults()
        {
            //  arrange
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });
            var terms = new[] { ".net", "java" };

            //  act
            var results = _model.GetTermSearchResults(terms);

            //  assert
            results.Count().Should().Be(6);
            results.Select(o => o.SearchEngineName).Distinct().Count().Should().Be(3);
            results.Select(o => o.Term).Distinct().Count().Should().Be(2);
            results.Select(o => o.Count).Sum().Should().Be(100 + 55 + 150 + 23 + 78 + 455);
        }

        [Fact]
        public void TryValidateTerms1()
        {
            //  arrange
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });

            //  act
            string[] validationErrors;
            _model.TryValidateTerms(null, out validationErrors).Should().BeFalse();
            validationErrors.Should().ContainSingle();
        }

        [Fact]
        public void TryValidateTerms2()
        {
            //  arrange
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });

            //  act
            string[] validationErrors;
            _model.TryValidateTerms(new[] { ".net" }, out validationErrors).Should().BeFalse();
            validationErrors.Should().ContainSingle();
        }

        [Fact]
        public void TryValidateTerms3()
        {
            //  arrange
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });

            //  act
            string[] validationErrors;
            _model.TryValidateTerms(new[] { ".net", ".Net" }, out validationErrors).Should().BeFalse();
            validationErrors.Should().ContainSingle();
        }

        [Fact]
        public void TryValidateTerms4()
        {
            //  arrange
            _model = new SearchFightModel(new[] { _engine1, _engine2, _engine3 });

            //  act
            string[] validationErrors;
            _model.TryValidateTerms(new[] { ".net", "java" }, out validationErrors).Should().BeTrue();
            validationErrors.Should().BeEmpty();
        }
    }
}