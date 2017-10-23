using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using SearchFight.Configuration;
using SearchFight.Configuration.Interfaces;
using SearchFight.SearchEngine;
using Xunit;

namespace SearchFight.Tests.SearchEngine
{
    public class SearcherLoaderTest
    {
        private readonly Mock<ISearchFightSectionSetup> _searchFightSectionSetupMock;

        public SearcherLoaderTest()
        {
            _searchFightSectionSetupMock = new Mock<ISearchFightSectionSetup>();
        }

        [Fact]
        public void It_Should_ReturnEmptyList_When_EmptySetupIsSent()
        {
            var seacherLoader = new SearcherLoader(_searchFightSectionSetupMock.Object);
            var result = seacherLoader.Handle();

            result.Should().NotBeNull();
        }

        [Fact]
        public void It_Should_ReturnSearcherList_When_ValidSetupIsSent()
        {
            var searcherElementSetups = new List<SearcherElementSetup>
            {
                new SearcherElementSetup
                {
                    Type = "SearchFight.Tests.SearchHandler.SimpleTestSearcher, SearchFight.Tests"
                },
                new SearcherElementSetup
                {
                    Type = "SearchFight.Tests.SearchHandler.FailTestSearcher, SearchFight.Tests"
                }
            };

            _searchFightSectionSetupMock.Setup(sfs => sfs.Searchers)
                .Returns(searcherElementSetups);

            var searcherLoader = new SearcherLoader(_searchFightSectionSetupMock.Object);
            var loadedSearchers = searcherLoader.Handle();

            loadedSearchers.Should().NotBeNull();
            loadedSearchers.Count().Should().Be(searcherElementSetups.Count);
        }

        [Fact]
        public void It_Should_ThrowInvalidOperationException_When_InvalidTypeIsTriedToBeInstantiated()
        {
            var searcherElementSetups = new List<SearcherElementSetup>
            {
                new SearcherElementSetup
                {
                    Type = "InvalidNamespace.InvalidClass, InvalidAssembly"
                }
            };

            _searchFightSectionSetupMock.Setup(sfs => sfs.Searchers)
                .Returns(searcherElementSetups);

            var searcherLoader = new SearcherLoader(_searchFightSectionSetupMock.Object);
            Assert.Throws<InvalidOperationException>(() => searcherLoader.Handle());
        }
    }
}
