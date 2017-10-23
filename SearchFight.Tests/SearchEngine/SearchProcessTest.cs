using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using SearchFight.Model;
using SearchFight.SearchEngine;
using SearchFight.SearchEngine.Interfaces;
using SearchFight.Tests.SearchHandler;
using Xunit;

namespace SearchFight.Tests.SearchEngine
{
    public class SearchProcessTest
    {
        private readonly Mock<ISearcherLoader> _searcherLoaderMock;
        private readonly Mock<IWinnerSearchCalculator> _winnerSearchCalculatorMock;

        public SearchProcessTest()
        {
            _searcherLoaderMock = new Mock<ISearcherLoader>();
            _winnerSearchCalculatorMock = new Mock<IWinnerSearchCalculator>();
        }

        [Fact]
        public void It_Should_RunSuccessfully_When_EmptyValuesAreSent()
        {
            _searcherLoaderMock.Setup(sl => sl.Handle())
                .Returns(new List<ISearcher>());
            _winnerSearchCalculatorMock.Setup(wsc => wsc.Handle(It.IsAny<IEnumerable<SearchResult>>()))
                .Returns(new TotalSearchResult());

            var searchProcess = new SearchProcess(_searcherLoaderMock.Object, _winnerSearchCalculatorMock.Object);
            var processResult = searchProcess.Run(new string[] { }).Result;

            processResult.Should().NotBeNull();
        }

        [Fact]
        public void It_Should_ThrowsNullReferenceException_When_NullValuesAreSent()
        {
            _searcherLoaderMock.Setup(sl => sl.Handle())
                   .Returns(new List<ISearcher>());

            var searchProcess = new SearchProcess(_searcherLoaderMock.Object, null);

            Assert.ThrowsAsync<NullReferenceException>(() => searchProcess.Run(null)).Wait();
        }

        [Fact]
        public void It_Should_UseAllSearchers_When_RunIsInvoked()
        {
            var searchers = new List<ISearcher>
            {
                new SimpleTestSearcher(),
                new SimpleTestSearcher(),
                new SimpleTestSearcher()
            };

            _searcherLoaderMock.Setup(sl => sl.Handle())
                .Returns(searchers);
            _winnerSearchCalculatorMock.Setup(wsc => wsc.Handle(
                    It.Is<IEnumerable<SearchResult>>(sr => sr.Count() == 2 && sr.All(result => result.SearcherResults.Count() == 3))))
                .Returns(new TotalSearchResult());

            var searchProcess = new SearchProcess(_searcherLoaderMock.Object, _winnerSearchCalculatorMock.Object);
            var processResult = searchProcess.Run(new[] { ".net", "java" }).Result;

            processResult.Should().NotBeNull();
        }
        
        [Fact]
        public void It_Should_StopProcess_When_SearcherFails()
        {
            var searchers = new List<ISearcher>
            {
                new SimpleTestSearcher(),
                new FailTestSearcher()
            };

            _searcherLoaderMock.Setup(sl => sl.Handle())
                .Returns(searchers);

            var searchProcess = new SearchProcess(_searcherLoaderMock.Object, _winnerSearchCalculatorMock.Object);
            
            Assert.ThrowsAsync<NotImplementedException>(() => searchProcess.Run(new[] { ".net", "java" })).Wait();
            _winnerSearchCalculatorMock.Verify(wsc => wsc.Handle(It.IsAny<IEnumerable<SearchResult>>()), Times.Never);
        }
    }
}
