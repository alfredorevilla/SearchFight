using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Models;
using ARevillaSearchFight.Presenters;
using ARevillaSearchFight.Views.Implementations;

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
                .AddSingleton<ISearchEngine, Engines.GoogleCustomSearchEngine>()
                .AddSingleton<ISearchEngine, Engines.BingSearch.BingSearchEngine>();

            var provider = services.BuildServiceProvider();

            var presenter = provider.GetRequiredService<SearchFightPresenter>();
        }
    }
}
