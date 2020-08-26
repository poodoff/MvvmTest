using System;
using Android.App;
using Android.OS;

namespace TopChartMvvm.Droid.Activities
{

    [Activity(Label = "Top Chart", Icon = "@mipmap/icon", Theme = "@style/AppTheme.Base")]
    public class DetailActivity : MvvmCross.Droid.Support.V7.AppCompat.MvxAppCompatActivity<Core.ViewModel.DetailViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetatilLayout);
        }
    }
}
