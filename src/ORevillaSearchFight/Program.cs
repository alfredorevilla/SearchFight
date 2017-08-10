using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SearchFight.Views;
using SearchFight.Models;
using SearchFight.Presenters;
using SearchFight.Views.Implementations;
using SearchFight.Search;
using SearchFight.Services;
using SearchFight.Services.Implementations;
using SearchFight.Models.Implementations;

namespace SearchFight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddSingleton<ISearchFightView, SearchFightConsoleView>()
                .AddSingleton<ISearchFightModel, SearchFightModel>()
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