using Xamarin.Forms;
using OpenGLGuide.ViewModels;

namespace OpenGLGuide.Pages
{
    public partial class StartedPage : ContentPage
    {
        public StartedPage()
        {
            InitializeComponent();
            _mainMenuView.ItemSelected += OnMainMenuViewItemSelected;
        }

        private void OnMainMenuViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                RedirectFromMenuItem(e.SelectedItem);
                _mainMenuView.SelectedItem = null;
            }
        }

        private void RedirectFromMenuItem(object item)
        {
            var vm = BindingContext as StartedViewModel;
            if (vm != null)
            {
                vm.OpenPage(item);
            }
        }
    }
}

