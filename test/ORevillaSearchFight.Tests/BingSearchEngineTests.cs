using ORevillaSearchFight.Engines.Microsoft;
using ORevillaSearchFight.Search;
using FluentAssertions;
using Xunit;

namespace ORevillaSearchFight.Tests
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