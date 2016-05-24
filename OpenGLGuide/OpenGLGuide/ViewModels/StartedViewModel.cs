using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace OpenGLGuide.ViewModels
{
    [ImplementPropertyChanged]
    public class StartedViewModel : FreshBasePageModel
    {

        private readonly Lazy<List<MenuItemViewModel>> _lazyLessonsSubItems;
        private Lazy<List<MenuItemViewModel>> _lazyLabWorksSubItems;

        public StartedViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>() { 
                new MenuItemViewModel("Уроки по OpenGL", null, OpenGLGuide.Enums.MenuItemTypes.GroupItem),
                new MenuItemViewModel("Лабораторные работы", null, OpenGLGuide.Enums.MenuItemTypes.GroupItem) 
            };

            _lazyLessonsSubItems = new Lazy<List<MenuItemViewModel>>(
                () => new List<MenuItemViewModel>() {
                    new MenuItemViewModel("Урок 1", "nehe01.jpg")
                });
        }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public void OpenPage(object item)
        {
            var itemViewModel = item as MenuItemViewModel;
            if (itemViewModel == null)
                return;
                
            if (itemViewModel.ItemType == OpenGLGuide.Enums.MenuItemTypes.GroupItem)
            {
                if (itemViewModel.ItemText == "Уроки по OpenGL")
                {
                    var startindex = 0;
                    foreach (var itemValue in _lazyLessonsSubItems.Value)
                    {
                        MenuItems.Insert(++startindex, itemValue);
                    }
                }
            }
        }

    }
}

