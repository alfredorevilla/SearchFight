using ARevillaSearchFight.Engines.Microsoft;
using ARevillaSearchFight.Search;
using FluentAssertions;
using Xunit;

namespace ARevillaSearchFight.Tests
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