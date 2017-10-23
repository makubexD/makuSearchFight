using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SearchFight.Common;

namespace SearchFight.Validations
{
    public class InputValidation
    {
        public OperationResult ValidParameters(string[] keyWords)
        {
            var validInformation = HasInformation(keyWords);
            var oneLineWords = string.Join(" ", keyWords);
            return validInformation.Success ? ValidateWords(oneLineWords) : validInformation;
        }

        public OperationResult HasInformation(string[] keyWords)
        {
            var operationResult = new OperationResult();
            if (keyWords.Length > 0) return operationResult;
            operationResult.AddMessage("You should enter a valid value");

            return operationResult;
        }

        public OperationResult ValidateWords(string keyWords)
        {
            var operationResult = new OperationResult();
            
            if (GetWords(keyWords).Count > 1) return operationResult;
            operationResult.AddMessage("You should enter at least two valid values");
            return operationResult;
        }

        public List<string> GetWords(string keyWords)
        {
            return Regex.Matches(keyWords, @"[\""].+?[\""]|[^ ]+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
        }
    }
}
