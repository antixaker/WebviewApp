using Xamarin.Forms;
using OpenGLGuide.ViewModels;
using OpenGLGuide.Effects;
using OpenGLGuide.Enums;

namespace OpenGLGuide.Pages
{
    public partial class StartedPage : ContentPage
    {
        public StartedPage()
        {
            InitializeComponent();
            _mainMenuView.ItemSelected += OnMainMenuViewItemSelected;

            GradientEffectExtentions.SetHasGradient(this.Content, true);
            GradientEffectExtentions.SetTypeOfGradient(this.Content, GradientType.Radial);
            GradientEffectExtentions.SetGradientCenter(this.Content, new Point(0, 0));
            GradientEffectExtentions.SetGradientRadius(this.Content, 1000);
            GradientEffectExtentions.SetFirstColor(this.Content, Color.FromHex("#31A38E"));
            GradientEffectExtentions.SetSecondColor(this.Content, Color.FromHex("#0E579B"));
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

