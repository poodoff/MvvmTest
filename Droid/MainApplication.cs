using System;
using Android.App;
using Android.Runtime;
using Core;

namespace TopChartMvvm.Droid
{
    [Application]
    public class MainApplication : MvvmCross.Platforms.Android.Views.MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
