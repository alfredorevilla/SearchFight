using FluentAssertions;
using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ARevillaSearchFight.Tests
{
    public class SearchFightModelExtensionsTests
    {
        IEnumerable<ModelTermSearchResult> _results;

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

            _results.GetOverallWinnerTerm().Should().Be("java");
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

            var result = _results.GetWinnersTermsPerSearchEngine();
            result.Count().Should().Be(2);
            result.Select(o => o.Term).Distinct().Count().Should().Be(1);
            result.Select(o => o.Term).Distinct().Single().Should().Be("java");
            result.Select(o => o.SearchEngineName).Distinct().Count().Should().Be(2);

        }

    }
}
