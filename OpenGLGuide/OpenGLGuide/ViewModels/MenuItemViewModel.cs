using System;
using FreshMvvm;
using PropertyChanged;
using OpenGLGuide.Enums;

namespace OpenGLGuide.ViewModels
{
    [ImplementPropertyChanged]
    public class MenuItemViewModel : FreshBasePageModel
    {
        public MenuItemViewModel(string text, string imageSource, string pageName, MenuItemTypes type = MenuItemTypes.DefaultItem)
        {
            ItemText = text;
            ImageSource = imageSource;
            ItemType = type;
            PageHtmlFileName = pageName;
        }

        public string PageHtmlFileName { get; set; }

        public bool IsDropDownOpened { get; set; }

        public MenuItemTypes ItemType { get; set; }

        public string ItemText { get; set; }

        public string ImageSource { get; set; }
    }
}

