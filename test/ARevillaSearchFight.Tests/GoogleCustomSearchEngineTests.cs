using FluentAssertions;
using ARevillaSearchFight.Engines.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ARevillaSearchFight.Tests
{
    public class GoogleCustomSearchEngineTests
    {

        GoogleCustomSearchEngine _engine;

        public GoogleCustomSearchEngineTests()
        {
            _engine = new GoogleCustomSearchEngine();
        }

        [Fact]
        public void GetBillGatesSearchTotalCountShouldReturnMoreThanZero()
        {
            //  act
            var total = _engine.GetSearchTotalCount("bill gates");

            //  assert
            total.Should().BeGreaterThan(0);
        }
    }
}
