using System;
using System.Threading.Tasks;
using Api.Repositories;
using Core.Bundle;
using MvvmCross.Logging;

namespace Core.ViewModel
{
    public class DetailViewModel : MvvmCross.ViewModels.MvxViewModel<DetailNavArgs>
    {
        private const string EmptyContent = "No content";
        private const string LargeImageSize = "large";

        private IArtistRepository _artistRepository;
        private IMvxLog _logger;
        private string _artistUid;

        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value, nameof(Loading));
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value, nameof(Content));
        }

        private string _mainImageUrl;
        public string MainImageUrl
        {
            get => _mainImageUrl;
            set => SetProperty(ref _mainImageUrl, value, nameof(MainImageUrl));
        }

        public DetailViewModel(IArtistRepository artistRepository, MvvmCross.Logging.IMvxLog logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }

        public override void Prepare(DetailNavArgs parameter)
        {
            _artistUid = parameter.ArtistUid;
        }

        public override async Task Initialize()
        {
            try
            {
                Loading = true;
                var artistInfo = await _artistRepository.GetInfo(_artistUid);
                if (artistInfo != null)
                {
                    Content = artistInfo.Bio?.Content ?? EmptyContent;
                    Name = artistInfo.Name;
                    var largeImage = artistInfo.Images?.Find(img => img.Size == LargeImageSize);
                    if (largeImage != null)
                        MainImageUrl = largeImage.Url;
                }
            }
            catch (Exception ex)
            {
                _logger.WarnException("Fail load detail info: ", ex);
            }
            finally
            {
                Loading = false;
            }
        }

    }
}
