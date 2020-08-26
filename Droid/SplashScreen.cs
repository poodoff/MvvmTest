using System;
using Android.App;
using Android.Content.PM;

namespace TopChartMvvm.Droid
{
    [Activity(
    Label = "LastFm Chart"
    , MainLauncher = true
    , Icon = "@mipmap/icon"
    , Theme = "@style/AppTheme.Splash"
    , NoHistory = true
    , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvvmCross.Droid.Support.V7.AppCompat.MvxSplashScreenAppCompatActivity
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
