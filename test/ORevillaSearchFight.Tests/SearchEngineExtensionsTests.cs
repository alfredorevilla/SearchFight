using FluentAssertions;
using SearchFight.Search;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;

namespace SearchFight.Tests
{
    public class SearchEngineExtensionsTests
    {
        private ISearchEngine _engine1;
        private ISearchEngine _engine2;
        private ISearchEngine _engine3;

        [Fact]
        public void GetName()
        {
            //  arrange
            _engine1 = A.Fake<ISearchEngine>(c => c.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine1), "")));
            _engine1.GetName().Should().Be(nameof(_engine1));
            _engine2 = A.Fake<ISearchEngine>(c => c.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine2), "")));
            _engine3 = A.Fake<ISearchEngine>(c => c.WithAttributes(() => new SearchEngineMetadataAttribute(nameof(_engine3), "")));

            //  assert
            _engine1.GetName().Should().Be(nameof(_engine1));
            _engine2.GetName().Should().Be(nameof(_engine2));
            _engine3.GetName().Should().Be(nameof(_engine3));
        }
    }
}