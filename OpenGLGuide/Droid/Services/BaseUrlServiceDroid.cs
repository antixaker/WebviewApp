using System;
using OpenGLGuide.Services;
using Xamarin.Forms;
using OpenGLGuide.Droid.Services;

[assembly: Dependency(typeof(BaseUrlServiceDroid))]
namespace OpenGLGuide.Droid.Services
{
    public class BaseUrlServiceDroid : IBaseUrlService
    {
        #region IBaseUrlService implementation

        public string Get()
        {
            return "file:///android_asset/";
        }

        #endregion
    }
}

