using System;
using FreshMvvm;
using PropertyChanged;
using OpenGLGuide.Enums;

namespace OpenGLGuide.ViewModels
{
    [ImplementPropertyChanged]
    public class MenuItemViewModel : FreshBasePageModel
    {
        public MenuItemViewModel(string text, string imageSource, MenuItemTypes type = MenuItemTypes.DefaultItem)
        {
            ItemText = text;
            ImageSource = imageSource;
            ItemType = type;
        }

        public bool IsAccordionOpened { get; set; }

        public MenuItemTypes ItemType { get; set; }

        public string ItemText { get; set; }

        public string ImageSource { get; set; }
    }
}

