﻿using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using SearchFight.Models;
using SearchFight.Services;
using SearchFight.Views;

namespace SearchFight.Presenters {

    public class SearchFightPresenterCtorArgs {

        public SearchFightPresenterCtorArgs(ISearchFightView view, ISearchFightModel model, ISearchFightService service, ISearchResultModelMapper mapper, ILoggerFactory loggerFactory) {
            this.View = view;
            this.Model = model;
            this.Service = service;
            this.Mapper = mapper;
            this.LoggerFactory = loggerFactory;
        }

        public SearchFightPresenterCtorArgs() {
        }

        public ILoggerFactory LoggerFactory { get; set; }

        [Required]
        public ISearchResultModelMapper Mapper { get; set; }

        [Required]
        public ISearchFightModel Model { get; set; }

        [Required]
        public ISearchFightService Service { get; set; }

        [Required]
        public ISearchFightView View { get; set; }
    }
}