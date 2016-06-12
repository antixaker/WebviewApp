using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using OpenGLGuide.Droid.Effects;
using OpenGLGuide.Effects;

[assembly: ExportEffect(typeof(GradientEffect), "GradientEffect")]
namespace OpenGLGuide.Droid.Effects
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
                gDrawable.SetColors(new int[] {
                        GradientEffectExtentions.GetFirstColor(elem).ToAndroid().ToArgb(), 
                        GradientEffectExtentions.GetSecondColor(elem).ToAndroid().ToArgb()
                    });
                var gradType = GradientEffectExtentions.GetTypeOfGradient(elem);
                if (gradType == OpenGLGuide.Enums.GradientType.Radial)
                {
                    var centerPoint = GradientEffectExtentions.GetGradientCenter(elem);
                    gDrawable.SetGradientCenter((float)centerPoint.X, (float)centerPoint.Y);
                    gDrawable.SetGradientRadius(GradientEffectExtentions.GetGradientRadius(elem));
                    gDrawable.SetGradientType(GradientType.RadialGradient);
                }
                else if (gradType == OpenGLGuide.Enums.GradientType.Linear)
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

