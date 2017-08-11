using SearchFight.Engines.Microsoft;
using SearchFight.Search;
using FluentAssertions;
using Xunit;

namespace SearchFight.Tests
{
    public class BingSearchEngineTests
    {
        private BingSearchEngine _engine;

        public BingSearchEngineTests()
        {
            _engine = new BingSearchEngine();
        }

        [Fact]
        public void GetBillGatesSearchTotalCountShouldReturnMoreThanZero()
        {
            var total = _engine.GetSearchTotalCount("bill gates");

            total.Should().BeGreaterThan(0);
        }
    }
}