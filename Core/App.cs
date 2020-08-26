using System;

namespace Core
{
    public class App : MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            new Api.App().Initialize();
            RegisterAppStart<ViewModel.MainViewModel>();
        }
    }
}
