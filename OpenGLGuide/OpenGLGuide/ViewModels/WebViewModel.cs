using System;
using OpenGLGuide.Services;
using PropertyChanged;
using FreshMvvm;
using Xamarin.Forms;
using System.IO;

namespace OpenGLGuide.ViewModels
{
    [ImplementPropertyChanged]
    public class WebViewModel : FreshBasePageModel
    {
        readonly IBaseUrlService _baseUrlService = DependencyService.Get<IBaseUrlService>();

        public override void Init(object initData)
        {
            base.Init(initData);

            Url = new UrlWebViewSource();
            var rootPath = _baseUrlService.Get();
            Url.Url = Path.Combine(rootPath, initData.ToString());
        }

        public UrlWebViewSource Url { get; set; }
    }
}

