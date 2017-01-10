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
    public class SearchFightTests2
    {

        [Fact]
        public void Fight()
        {

            var engine1 = A.Fake<ISearchEngine>();
            var engine2 = A.Fake<ISearchEngine>();
            var engines = new[] { engine1, engine2 };
            var output = A.Fake<IOutput>();
            A.CallTo(() => engine1.Search(".net")).Returns(new SearchResults(engine1, ".net", A.CollectionOfFake<SearchResultItem>(100)));
            A.CallTo(() => engine1.Search(".java")).Returns(new SearchResults(engine1, "java", A.CollectionOfFake<SearchResultItem>(150)));
            A.CallTo(() => engine2.Search(".net")).Returns(new SearchResults(engine2, ".net", A.CollectionOfFake<SearchResultItem>(200)));
            A.CallTo(() => engine2.Search(".java")).Returns(new SearchResults(engine2, "java", A.CollectionOfFake<SearchResultItem>(300)));

            var fight = new SearchFight(new[] { engine1, engine2 }, output);
            fight.Invoking(o => o.Fight(new[] { ".net", "java" }));

            var terms = new[] { ".net", "java" };

        }

        [Fact]
        public void GetMatrix()
        {
            var engine1 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine1.Name).Returns(nameof(engine1));
            var engine2 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine2.Name).Returns(nameof(engine2));
            var engine3 = A.Fake<ISearchEngine>();
            A.CallTo(() => engine3.Name).Returns(nameof(engine3));
            var result = new SearchResults[] {
                new SearchResults(engine1, ".net", A.CollectionOfFake<SearchResultItem>(100)),
                new SearchResults(engine1, "java", A.CollectionOfFake<SearchResultItem>(150)),
                new SearchResults(engine2, ".net", A.CollectionOfFake<SearchResultItem>(200)),
                new SearchResults(engine2, "java", A.CollectionOfFake<SearchResultItem>(300)),
                new SearchResults(engine3, ".net", A.CollectionOfFake<SearchResultItem>(200)),
                new SearchResults(engine3, "java", A.CollectionOfFake<SearchResultItem>(300))
            };
            var matrix = SearchFight.BuildMatrix(result, SearchResultsMatrixOptions.EnginesAsHeaders);


            int y = 0, x = 0;
            matrix[0, 0].Should().BeNull();
            matrix[++y, x].ToString().Should().Be(".net");
            matrix[++y, x].ToString().Should().Be("java");



        }
    }
}
