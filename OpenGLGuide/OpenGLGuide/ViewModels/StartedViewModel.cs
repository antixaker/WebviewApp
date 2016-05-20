using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using PropertyChanged;

namespace OpenGLGuide.ViewModels
{
    [ImplementPropertyChanged]
    public class StartedViewModel : FreshBasePageModel
    {
        private Command _openPage;

        public StartedViewModel()
        {
            MenuItems = new List<string>(){ "Уроки по OpenGL", "Лабораторные работы" };
        }

        public List<string> MenuItems { get; set; }

        public Command OpenPage
        {
            get
            {
                return _openPage ?? (_openPage = new Command(() =>
                    {
                    }));
            } 
        }


    }
}

