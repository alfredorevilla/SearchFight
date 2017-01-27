using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Models;
using ARevillaSearchFight.Presenters;
using ARevillaSearchFight.Views.Implementations;
using ARevillaSearchFight.Search;
using ARevillaSearchFight.Services;
using ARevillaSearchFight.Services.Implementations;

namespace ARevillaSearchFight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddSingleton<ISearchFightView, SearchFightConsoleView>()
                .AddSingleton<ISearchFightModel, Models.Implementations.SearchFightModel>()
                .AddSingleton<ISearchEngine, Engines.Google.GoogleCustomSearchEngine>()
                .AddSingleton<ISearchEngine, Engines.Microsoft.BingSearchEngine>()
                .AddSingleton<SearchFightPresenterCtorArgs>()
                .AddSingleton<SearchFightPresenter>()
                .AddSingleton<ISearchFightService, SearchFightService>()
                .AddSingleton<ISearchResultModelMapper, SearchResultModelMapper>()
                .AddLogging();

            var provider = services.BuildServiceProvider();

            var presenter = provider.GetRequiredService<SearchFightPresenter>();
            presenter.SearchAndFight(terms: args);
        }
    }
}