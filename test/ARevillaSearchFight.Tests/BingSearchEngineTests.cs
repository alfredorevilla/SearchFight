﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ARevillaSearchFight.Engines.Microsoft;

namespace ARevillaSearchFight.Tests
{
    public class BingSearchEngineTests
    {
        BingSearchEngine _engine;
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
