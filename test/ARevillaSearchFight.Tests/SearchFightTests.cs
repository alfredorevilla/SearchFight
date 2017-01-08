//using ARevillaSearchFight.Models;
//using FakeItEasy;
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using Xunit.Abstractions;

//namespace ARevillaSearchFight.Tests
//{
//    public class SearchFightTests
//    {

//        ISearchEngine _engine1;
//        IOutput _output;

//        public SearchFightTests()
//        {
//            _engine1 = A.Fake<ISearchEngine>();
//            A.CallTo(() => _engine1.Search("")).WithAnyArguments().Returns(new SearchResult(new SearchResultItem[0] { }));
//            _output = A.Fake<IOutput>();
//            A.CallTo(() => _output.WriteLine("")).WithAnyArguments().Invokes((fake) => Console.WriteLine(fake.GetArgument<string>(0)));
//            var instance = new SearchFight(new[] { _engine1 }, _output);
//        }

//        [Fact]
//        public void Search()
//        {
//            //  arrange
//            var engine1 = A.Fake<ISearchEngine>();
//            A.CallTo(() => engine1.Search("")).WithAnyArguments().Returns(new SearchResult(new SearchResultItem[0] { }));
//            var output = A.Fake<IOutput>();
//            A.CallTo(() => output.WriteLine("")).WithAnyArguments().Invokes((fake) => Console.WriteLine(fake.GetArgument<string>(0)));
//            var instance = new SearchFight(new[] { engine1 }, output);
//            var terms = new[] { "cignium", "street fighter" };

//            //  act
//            var result = instance.Fight(terms);

//            //  assert
//            result.Should().HaveCount(terms.Length);
//        }

//        [Fact]
//        public void SearchWontAcceptNullOrZeroTerms()
//        {
//            //  arrange
//            var instance = new SearchFight(new[] { _engine1 }, _output);

//            //  act
//            var a = this.Invoking((o) => instance.Fight(null));
//            var a2 = this.Invoking((o) => instance.Fight(new string[] { }));

//            //  assert
//            a.ShouldThrow<ArgumentException>();
//            a2.ShouldThrow<ArgumentException>();
//        }
//    }
//}
