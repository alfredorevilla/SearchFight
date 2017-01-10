using FluentAssertions;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ARevillaSearchFight.Models;

namespace ARevillaSearchFight.Tests
{
    public class SearchFightTests
    {

        [Fact]
        public void ResultingMatrixShouldContainAllGivenSearchTermsOnce()
        {
            //  arrange
            var engine1 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine1.Name).Returns(nameof(engine1));
            var engine2 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine2.Name).Returns(nameof(engine2));
            var engine3 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine3.Name).Returns(nameof(engine3));
            var terms = new[] { ".net", "java" };
            var result = new SearchResults[] {
                new SearchResults(engine1, ".net", A.CollectionOfFake<SearchResultItem>(100)),
                new SearchResults(engine1, "java", A.CollectionOfFake<SearchResultItem>(150)),
                new SearchResults(engine2, ".net", A.CollectionOfFake<SearchResultItem>(200)),
                new SearchResults(engine2, "java", A.CollectionOfFake<SearchResultItem>(300)),
                new SearchResults(engine3, ".net", A.CollectionOfFake<SearchResultItem>(200)),
                new SearchResults(engine3, "java", A.CollectionOfFake<SearchResultItem>(300))
            };

            //  act
            var matrix = SearchFight.BuildTermPerEngineSearchResultCountMatrix(result);

            //  assert
            int y = 0, x = 0;
            matrix[0, 0].Should().BeNull();
            terms.Should().Contain(matrix[++y, x].ToString());
            terms.Should().Contain(matrix[++y, x].ToString());

        }
    }
}
