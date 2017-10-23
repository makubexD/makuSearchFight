using System.Linq;
using System.Text;
using SearchFight.Configuration;
using SearchFight.Model;
using SearchFight.SearchEngine;
using SearchFight.Validations;

namespace SearchFight
{
    public class SearcherEngine
    {
        public string Execute(string[] keyWords)
        {
            var validation = new InputValidation().ValidParameters(keyWords);
            if (!validation.Success)
                return validation.MessageList.FirstOrDefault();

            var config = new SearchFightSectionSetup(SearchFightSection.Configuration);
            var searcherLoader = new SearcherLoader(config);
            var searchProcess = new SearchProcess(searcherLoader, new WinnerSearchCalculator());

            var processResult = searchProcess.Run(keyWords).Result;

            return Display(processResult);
        }

        public string Display(TotalSearchResult totalSearchResult)
        {
            var builderResult = new StringBuilder();
            
            builderResult.AppendLine("====== Process Report ======");
            totalSearchResult.SearchResults.ForEach(sr => 
            {
                builderResult.Append($"[{sr.SearchTerm}] => ");
                foreach (var searcherResult in sr.SearcherResults)
                {
                    builderResult.Append($"{searcherResult.SearcherName}: {searcherResult.Total} ");
                }
                
                builderResult.AppendLine("");
            });

            totalSearchResult.IndividualWinners.ForEach(iw => 
            {
                builderResult.AppendLine($"{iw.SearcherName} winner: {iw.SearchTerm}");
            });

            builderResult.AppendLine($"Total winner: {totalSearchResult.GlobalWinner}");
            builderResult.AppendLine("============================");

            return builderResult.ToString();
        }
    }
}
