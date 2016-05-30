using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using TakedaEntivyo.Effects;
using TakedaEntivyo.Droid.Effects;

[assembly: ExportEffect(typeof(GradientEffect), "GradientEffect")]
namespace TakedaEntivyo.Droid.Effects
{
    public class GradientEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var view = Element as View;
            if (view != null)
            {
                view.SizeChanged += OnElementSizeChanged;
            }
        }

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var elem = sender as View;
            if (elem == null)
                return;

            using (var gDrawable = new GradientDrawable())
            {
                gDrawable.SetColors(new int[]
                    {
                        ViewEffectExtentions.GetFirstColor(elem).ToAndroid().ToArgb(), 
                        ViewEffectExtentions.GetSecondColor(elem).ToAndroid().ToArgb()
                    });
                var gradType = ViewEffectExtentions.GetTypeOfGradient(elem);
                if (gradType == TakedaEntivyo.Effects.GradientType.Radial)
                {
                    var centerPoint = ViewEffectExtentions.GetGradientCenter(elem);
                    gDrawable.SetGradientCenter((float)centerPoint.X, (float)centerPoint.Y);
                    gDrawable.SetGradientRadius(ViewEffectExtentions.GetGradientRadius(elem));
                    gDrawable.SetGradientType(Android.Graphics.Drawables.GradientType.RadialGradient);
                }
                else if (gradType == TakedaEntivyo.Effects.GradientType.Linear)
                {
                    throw new NotImplementedException();
                }

                Container.Background = gDrawable;
            }
        }

        protected override void OnDetached()
        {
            var view = Element as View;
            if (view != null)
            {
                view.SizeChanged -= OnElementSizeChanged;
            }
        }
    }
}

