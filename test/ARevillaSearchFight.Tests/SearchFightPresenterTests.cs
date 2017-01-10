using ARevillaSearchFight.Models;
using ARevillaSearchFight.Presenters;
using ARevillaSearchFight.Views;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Tests
{
    public class SearchFightPresenterTests
    {
        SearchFightPresenter _presenter;
        ISearchFightView _view;
        ISearchFightModel _model;

        public SearchFightPresenterTests()
        {
            _view = A.Fake<ISearchFightView>();            
            _model = A.Fake<ISearchFightModel>();
            _presenter = new SearchFightPresenter(_view, _model);
        }

        public void Test1()
        {
            
        }
    }
}
