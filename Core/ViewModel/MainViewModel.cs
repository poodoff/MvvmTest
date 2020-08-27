using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories;
using Core.Bundle;
using Core.ViewModel.Items;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Core.ViewModel
{
    public class MainViewModel : MvvmCross.ViewModels.MvxViewModel
    {
        private IChartRepository _chartRepository;
        private IMvxNavigationService _navigationService;
        private IMvxLog _logger;

        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value, nameof(Loading));
        }

        private MvxObservableCollection<ItemViewModel> _items;
        public MvxObservableCollection<ItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value, nameof(Items));
        }

        public MainViewModel(IChartRepository chartRepository, MvvmCross.Navigation.IMvxNavigationService navigationService, MvvmCross.Logging.IMvxLog logger)
        {
            _chartRepository = chartRepository;
            _navigationService = navigationService;
            _logger = logger;
        }

        public override async Task Initialize()
        {
            try
            {
                Loading = true;
                var topArtists = await _chartRepository.GetTopAtists();
                if (topArtists != null)
                {
                    var artistModels = topArtists.Select(artist => new ItemViewModel(artist)).ToList();
                    Items = new MvxObservableCollection<ItemViewModel>(artistModels);
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Нет данных для отображения");
                }
            }
            catch (Exception ex)
            {
                _logger.WarnException("Fail load artists: ", ex);
                Acr.UserDialogs.UserDialogs.Instance.Alert("Проблемы при загрузке данных");
            }
            finally
            {
                Loading = false;
            }
        }

        private IMvxCommand _itemClickCommand;
        public IMvxCommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new MvxCommand<ItemViewModel>(OnItemClick));

        private void OnItemClick(ItemViewModel viewModel)
        {
            if (viewModel == null || (string.IsNullOrEmpty(viewModel.Uid) && string.IsNullOrEmpty(viewModel.Title)))
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("Информация недоступна");
                return;
            }
            _navigationService.Navigate<DetailViewModel, DetailNavArgs>(new DetailNavArgs(viewModel.Uid, viewModel.Title));
        }
    }
}
