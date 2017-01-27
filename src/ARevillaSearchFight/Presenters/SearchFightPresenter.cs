﻿using ARevillaSearchFight.Models;
using ARevillaSearchFight.Views;
using ARevillaSearchFight.Views.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using ARevillaSearchFight.Services;

namespace ARevillaSearchFight.Presenters
{
    public class SearchFightPresenter
    {
        private ILogger<SearchFightPresenter> _logger;

        public SearchFightPresenter(SearchFightPresenterCtorArgs args)
        {
            Validator.ValidateObject(args, new ValidationContext(args), true);

            this.View = args.View;
            this.Model = args.Model;
            this.Service = args.Service;
            this.Mapper = args.Mapper;
            _logger = args.LoggerFactory?.CreateLogger<SearchFightPresenter>();
        }

        public ISearchResultModelMapper Mapper { get; set; }
        public ISearchFightModel Model { get; }
        public ISearchFightService Service { get; set; }
        public ISearchFightView View { get; }

        public void SearchAndFight(string[] terms)
        {
            string[] validationErrors;
            if (!this.Model.TryValidateTerms(terms: terms, validationErrors: out validationErrors))
            {
                this.View.RenderWarningList(titleOrCategory: "Validation errors", items: validationErrors);
                return;
            }
            try
            {
                var modelResults = this.Model.GetTermSearchResults(terms);

                this.View.RenderSearchAndFightData(new Views.Models.SearchAndFightModel
                {
                    SearchResults = this.Mapper.ToViewDataModel(modelResults).ToArray(),
                    WinnerTerms = this.Mapper.ToViewDataModel(this.Service.GetWinnersTermsPerSearchEngine(modelResults)).ToArray(),
                    OverallWinnerTerm = this.Service.GetOverallWinnerTerm(modelResults),
                });
            }
            catch (System.Exception e)
            {
                this.View.RenderError(e.Message);
            }
        }

        private void View_SearchAndFight(object sender, SearchAndFightArgs e)
        {
            this.SearchAndFight(e.Terms);
        }
    }
}