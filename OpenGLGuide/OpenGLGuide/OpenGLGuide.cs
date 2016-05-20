using System;

using Xamarin.Forms;
using FreshMvvm;
using OpenGLGuide.ViewModels;

namespace OpenGLGuide
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            var page = FreshPageModelResolver.ResolvePageModel<StartedViewModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

