using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreshMvvm;
using PropertyChanged;

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
                new MenuItemViewModel("Уроки по OpenGL", null, null, OpenGLGuide.Enums.MenuItemTypes.GroupItem),
                new MenuItemViewModel("Лабораторные работы", null, null, OpenGLGuide.Enums.MenuItemTypes.GroupItem) 
            };

            _lazyLessonsSubItems = new Lazy<List<MenuItemViewModel>>(() =>
                {
                    var list = new List<MenuItemViewModel>();
                    for (int i = 1; i <= 42; i++)
                        list.Add(new MenuItemViewModel(string.Format("Урок {0}", i), string.Format("nehe{0}.jpg", IntToStringConverter(i)), string.Format("nehe{0}.htm", IntToStringConverter(i))));

                    return list;
                }
            );
        }

        private string IntToStringConverter(int value)
        {
            return value < 10 ? string.Format("0{0}", value) : value.ToString();
        }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public async void OpenPage(object item)
        {
            var itemViewModel = item as MenuItemViewModel;
            if (itemViewModel == null)
                return;
                
            if (itemViewModel.ItemType == OpenGLGuide.Enums.MenuItemTypes.GroupItem)
            {
                if (itemViewModel.ItemText == "Уроки по OpenGL")
                {
                    if (!itemViewModel.IsDropDownOpened)
                    {
                        var startindex = 0;
                        foreach (var itemValue in _lazyLessonsSubItems.Value)
                        {
                            MenuItems.Insert(++startindex, itemValue);
                        }
                        itemViewModel.IsDropDownOpened = true;
                    }
                    else
                    {
                        var tmp = new MenuItemViewModel[MenuItems.Count];
                        MenuItems.CopyTo(tmp, 0);
                        var tmpList = new List<MenuItemViewModel>(tmp);

                        foreach (var itemValue in _lazyLessonsSubItems.Value)
                        {
                            if (tmpList.Contains(itemValue))
                                tmpList.Remove(itemValue);
                        }

                        MenuItems = new ObservableCollection<MenuItemViewModel>(tmpList);
                        itemViewModel.IsDropDownOpened = false;
                    }
                }
            }
            else if (itemViewModel.ItemType == OpenGLGuide.Enums.MenuItemTypes.DefaultItem)
            {
                await CoreMethods.PushPageModel<WebViewModel>(itemViewModel.PageHtmlFileName);
            }
        }

    }
}

