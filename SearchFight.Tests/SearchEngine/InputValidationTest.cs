using System.Linq;
using FluentAssertions;
using SearchFight.Validations;
using Xunit;

namespace SearchFight.Tests.SearchEngine
{
    public class InputValidationTest
    {
        [Fact]
        public void It_Should_ReturnMessageValidation_When_NoWordsAreEntered()
        {
            string[] inputWord = {};

            var operationResult = new InputValidation().HasInformation(inputWord);

            operationResult.MessageList.FirstOrDefault().Should().Be("You should enter a valid value");
        }

        [Fact]
        public void It_Should_ReturnMessageValidation_When_OneWordIsEntered()
        {
            const string inputWord = "Java";

            var operationResult = new InputValidation().ValidateWords(inputWord);

            operationResult.MessageList.FirstOrDefault().Should().Be("You should enter at least two valid values");
        }

        [Fact]
        public void It_Should_ValidateQuotation_When_WordsIncludeQuotation()
        {
            const string inputWord = ".net \"Java Script\"";

            var count = new InputValidation().GetWords(inputWord).Count;

            count.Should().Be(2);
        }
    }
}
