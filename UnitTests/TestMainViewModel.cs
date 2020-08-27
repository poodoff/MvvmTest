using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Artist;
using Api.Repositories;
using Core.ViewModel;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    public class TestsMainViewModel
    {
        const int ArtistsCount = 3;

        private MainViewModel _mainViewModel;
        private Mock<IChartRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Moq.Mock<IChartRepository>();
            var mockNavigationService = new Moq.Mock<MvvmCross.Navigation.IMvxNavigationService>();
            var mockLoger = new Moq.Mock<MvvmCross.Logging.IMvxLog>();

            _mainViewModel = new MainViewModel(_mockRepository.Object, mockNavigationService.Object, mockLoger.Object);
        }

        List<SimpleArtistModel> GetThreeTopArtists()
        {
            return new List<SimpleArtistModel>
            {
                new SimpleArtistModel(){ Id = Guid.NewGuid().ToString(), Name = "Avicii"},
                new SimpleArtistModel(){ Id = Guid.NewGuid().ToString(), Name = "alt-J"},
                new SimpleArtistModel(){ Id = Guid.NewGuid().ToString(), Name = "Camila Cabello"},
            };
        }

        [Test]
        public void TestLoadAndShowArtists()
        {
            var topArtists = GetThreeTopArtists();
            _mockRepository.Setup(repo => repo.GetTopAtists(It.IsAny<int>())).ReturnsAsync(topArtists);

            _mainViewModel.Initialize().Wait();
            _mockRepository.Verify(repo => repo.GetTopAtists(It.IsAny<int>()), Times.Once);

            Assert.AreEqual(_mainViewModel.Items?.Count, ArtistsCount);
        }

        [Test]
        public void TestLoadEmptyArtist()
        {
            var emptyArtists = new List<SimpleArtistModel>();
            _mockRepository.Setup(repo => repo.GetTopAtists(It.IsAny<int>())).ReturnsAsync(emptyArtists);

            Assert.DoesNotThrowAsync(() => _mainViewModel.Initialize());
            _mockRepository.Verify(repo => repo.GetTopAtists(It.IsAny<int>()), Times.Once);

            Assert.AreEqual(_mainViewModel.Items?.Count, 0);
        }

    }
}