using System;
using Api.Models;

namespace Core.ViewModel.Items
{
    public class ItemViewModel
    {
        protected const string SizeMedium = "medium";

        public SimpleArtistModel Artist { get; }

        public string Title => Artist?.Name ?? string.Empty;

        public string ImgUrl { get; }

        public ItemViewModel(SimpleArtistModel simpleAritstModel)
        {
            Artist = simpleAritstModel;
            ImgUrl = simpleAritstModel?.Images?.Find(img => img.Size == SizeMedium).Url ?? string.Empty;
        }
    }
}
