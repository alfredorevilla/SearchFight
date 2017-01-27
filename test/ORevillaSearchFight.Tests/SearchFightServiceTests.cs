using FluentAssertions;
using ORevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ORevillaSearchFight.Services;
using ORevillaSearchFight.Services.Implementations;

namespace ORevillaSearchFight.Tests
{
    public class SearchFightServiceTests
    {
        private IEnumerable<ModelTermSearchResult> _results;

        private SearchFightService _service;

        public SearchFightServiceTests()
        {
            _service = new SearchFightService();
        }

        [Fact]
        public void GetOverallWinnerTerm()
        {
            //  arrange
            _results = new[]
            {
                new ModelTermSearchResult
                {
                    Count = 100,
                    SearchEngineName = "engine1",
                    Term = ".net"
                },
                new ModelTermSearchResult
                {
                    Count = 101,
                    SearchEngineName = "engine1",
                    Term = "java"
                },
                new ModelTermSearchResult
                {
                    Count = 103,
                    SearchEngineName = "engine2",
                    Term = ".net"
                },
                new ModelTermSearchResult
                {
                    Count = 104,
                    SearchEngineName = "engine2",
                    Term = "java"
                },
            };

            _service.GetOverallWinnerTerm(_results).Should().Be("java");
        }

        [Fact]
        public void GetWinnersTermsPerSearchEngine()
        {
            //  arrange
            _results = new[]
            {
                new ModelTermSearchResult
                {
                    Count = 100,
                    SearchEngineName = "engine1",
                    Term = ".net"
                },
                new ModelTermSearchResult
                {
                    Count = 101,
                    SearchEngineName = "engine1",
                    Term = "java"
                },
                new ModelTermSearchResult
                {
                    Count = 103,
                    SearchEngineName = "engine2",
                    Term = ".net"
                },
                new ModelTermSearchResult
                {
                    Count = 104,
                    SearchEngineName = "engine2",
                    Term = "java"
                },
            };

            var result = _service.GetWinnersTermsPerSearchEngine(_results);
            result.Count().Should().Be(2);
            result.Select(o => o.Term).Distinct().Count().Should().Be(1);
            result.Select(o => o.Term).Distinct().Single().Should().Be("java");
            result.Select(o => o.SearchEngineName).Distinct().Count().Should().Be(2);
        }
    }
}