﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Views.Models;

namespace ARevillaSearchFight.Views.Implementations
{
    public class SearchFightConsoleView : ISearchFightView
    {
        protected virtual void OnSearchAndFight(string[] terms)
        {
            this.SearchAndFight?.Invoke(this, new Models.SearchAndFightArgs(terms));
        }

        public event EventHandler<SearchAndFightArgs> SearchAndFight;

        public ConsoleColor ForegroundColor
        {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }

        public ConsoleColor BackgroundColor
        {
            get { return Console.BackgroundColor; }
            set { Console.BackgroundColor = value; }
        }

        public void RenderError(string message)
        {
            Console.WriteLine();
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error: {message}]");
            this.ForegroundColor = color;
        }

        public void RenderMessage(string message)
        {
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(message);
            this.ForegroundColor = color;
        }

        public void RenderSearchAndFightData(SearchAndFightData data)
        {
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("[Results:]");
            var engineNames = data.SearchResults.Select(o => o.SearchEngineName);
            var group = data.SearchResults.GroupBy(o => o.Term);
            foreach (var item in group)
            {
                Console.WriteLine($"{item.Key}: {string.Join(" ", item.Select(o => $"{o.SearchEngineName}: {o.Count}"))}");
            }
            this.ForegroundColor = color;
        }

        public void RenderWarningList(string titleOrCategory, string[] items)
        {
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(titleOrCategory))
            {
                Console.WriteLine(titleOrCategory);
            }
            foreach (var item in items)
            {
                Console.WriteLine($"• {item}");
            }
        }
    }
}
