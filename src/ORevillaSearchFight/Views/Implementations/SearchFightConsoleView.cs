using System;
using System.Linq;
using ORevillaSearchFight.Views.Models;

namespace ORevillaSearchFight.Views.Implementations {
    public class SearchFightConsoleView : ISearchFightView {

        public ConsoleColor BackgroundColor {
            get { return Console.BackgroundColor; }
            set { Console.BackgroundColor = value; }
        }

        public ConsoleColor ForegroundColor {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }

        public void RenderError(string message) {
            Console.WriteLine();
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error: {message}]");
            this.ForegroundColor = color;
        }

        public void RenderMessage(string message) {
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(message);
            this.ForegroundColor = color;
        }

        public void RenderSearchAndFightData(SearchAndFightModel model) {
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=== Results: ===");
            Console.WriteLine();
            var engineNames = model.SearchResults.Select(o => o.SearchEngineName);
            var group = model.SearchResults.GroupBy(o => o.Term);
            foreach (var item in group) {
                Console.WriteLine($"{item.Key}: {string.Join(" ", item.Select(o => $"{o.SearchEngineName}: {o.Count}"))}");
            }
            Console.WriteLine();
            foreach (var item in model.WinnerTerms) {
                Console.WriteLine($"{item.SearchEngineName} winner: {item.Term}");
            }
            Console.WriteLine();
            Console.WriteLine($"Overall winner: {model.OverallWinnerTerm}");
            this.ForegroundColor = color;
        }

        public void RenderWarningList(string titleOrCategory, string[] items) {
            var color = this.ForegroundColor;
            this.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(titleOrCategory)) {
                Console.WriteLine(titleOrCategory);
            }
            foreach (var item in items) {
                Console.WriteLine($"* {item}");
            }
            this.ForegroundColor = color;
        }
    }
}