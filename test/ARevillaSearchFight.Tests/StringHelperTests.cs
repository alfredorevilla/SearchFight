using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ARevillaSearchFight.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void RemoveExtraWhitespaces1()
        {
            var value = StringHelper.RemoveExtraWhitespaces("  ");

            value.Should().Be("");

        }

        [Fact]
        public void RemoveExtraWhitespaces2()
        {
            var value = StringHelper.RemoveExtraWhitespaces("  alfredo  revilla       ");

            value.Should().Be("alfredo revilla");
        }
    }
}
