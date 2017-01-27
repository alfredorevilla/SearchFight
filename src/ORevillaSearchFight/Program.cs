using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ORevillaSearchFight.Views;
using ORevillaSearchFight.Models;
using ORevillaSearchFight.Presenters;
using ORevillaSearchFight.Views.Implementations;
using ORevillaSearchFight.Search;
using ORevillaSearchFight.Services;
using ORevillaSearchFight.Services.Implementations;
using ORevillaSearchFight.Models.Implementations;

namespace ORevillaSearchFight
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