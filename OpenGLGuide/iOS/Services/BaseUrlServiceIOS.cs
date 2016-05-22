using System;
using OpenGLGuide.Services;
using Xamarin.Forms;
using OpenGLGuide.iOS.Services;
using Foundation;

[assembly: Dependency(typeof(BaseUrlServiceIOS))]
namespace OpenGLGuide.iOS.Services
{
    public class BaseUrlServiceIOS : IBaseUrlService
    {
        #region IBaseUrlService implementation

        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }

        #endregion
    }
}

