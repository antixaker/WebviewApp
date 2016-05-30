using System;
using Xamarin.Forms;
using OpenGLGuide.ViewModels;
using OpenGLGuide.Enums;

namespace OpenGLGuide.Helpers
{
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }

        public DataTemplate AccordionDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var menuItem = item as MenuItemViewModel;
            if (menuItem == null)
                throw new Exception("Unknown menu cell type");

            switch (menuItem.ItemType)
            {
                case MenuItemTypes.DefaultItem:
                    return DefaultDataTemplate;
                case MenuItemTypes.GroupItem:
                    return AccordionDataTemplate;
                default:
                    throw new Exception("Unknown menu cell type");
            }

        }
    }
}

