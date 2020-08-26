using System;
using System.Net.Http;
using Api.Repositories;
using MvvmCross.IoC;

namespace Api
{
    public class App : MvvmCross.ViewModels.MvxApplication
    {
        public const string MainUrl = "http://ws.audioscrobbler.com/2.0/";
        public const string ApiKey = "6261b95fc5394d5cc224dc052e36ff95";

        public override void Initialize()
        {
            MvvmCross.Mvx.IoCProvider.RegisterSingleton(InitHttpClient());

            MvvmCross.Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IChartRepository, ChartRepositoryImpl>();
            MvvmCross.Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IArtistRepository, ArtistRepository>();
        }

        HttpClient InitHttpClient()
        {
            //TODO specific headers
            return new HttpClient();
        }
    }
}
