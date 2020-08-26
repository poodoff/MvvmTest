using Android.App;
using Android.Widget;
using Android.OS;
using Core.ViewModel;

namespace TopChartMvvm.Droid
{
    [Activity(Label = "Top Chart",Icon = "@mipmap/icon", Theme = "@style/AppTheme.Base")]
    public class MainActivity : MvvmCross.Droid.Support.V7.AppCompat.MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

        }
    }
}

