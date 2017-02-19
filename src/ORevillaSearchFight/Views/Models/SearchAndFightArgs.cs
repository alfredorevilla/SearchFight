﻿using System;

namespace ORevillaSearchFight.Views.Models {
    public class SearchAndFightArgs : EventArgs {

        public SearchAndFightArgs(string[] terms) {
            this.Terms = terms;
        }

        public string[] Terms { get; }
    }
}