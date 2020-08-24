using System;
namespace Core.ViewModel.Items
{
    public class ItemViewModel
    {
        public string Title { get; set; }

        public ItemViewModel(string title)
        {
            Title = title;
        }
    }
}
