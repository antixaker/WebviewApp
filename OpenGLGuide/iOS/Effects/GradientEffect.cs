using System;
using Xamarin.Forms;
using OpenGLGuide.iOS.Effects;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using UIKit;
using OpenGLGuide.Effects;
using System.Collections.Generic;
using OpenGLGuide.Enums;

[assembly: ExportEffect(typeof(GradientEffect), "GradientEffect")]
namespace OpenGLGuide.iOS.Effects
{
    public class GradientEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var currentView = this.Element as View;
            if (currentView != null)
            {
                currentView.SizeChanged += OnElementSizeChanged;
            }
        }

        void OnElementSizeChanged(object sender, EventArgs e)
        {
            var element = sender as View;
            if (element == null)
                return;

            var bounds = element.Bounds;
            var rect = new CGRect(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            UIGraphics.BeginImageContext(rect.Size);
            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                using (var rgb = CGColorSpace.CreateDeviceRGB())
                {
                    nfloat[] colors = null;
                    if (GradientEffectExtentions.GetColorList(element) != null)
                    {
                        colors = GetFloatArrayFromColors(GradientEffectExtentions.GetColorList(element));
                    }
                    else
                    {
                        colors = GetFloatArrayFromColors(GradientEffectExtentions.GetFirstColor(element), GradientEffectExtentions.GetSecondColor(element));
                    }

                    nfloat[] locations = null;
                    if (GradientEffectExtentions.GetLocationsList(element) != null)
                    {
                        locations = GetFloatArrayFromLocations(GradientEffectExtentions.GetLocationsList(element));
                    }

                    var gradient = new CGGradient(rgb, colors, locations);

                    var gradType = GradientEffectExtentions.GetTypeOfGradient(element);
                    if (gradType == GradientType.Radial)
                    {
                        var centerPoint = GradientEffectExtentions.GetGradientCenter(element);
                        var radius = GradientEffectExtentions.GetGradientRadius(element);

                        g.DrawRadialGradient(gradient, new CGPoint(centerPoint.X, centerPoint.Y), new nfloat(0), new CGPoint(radius, radius), new nfloat(radius), CGGradientDrawingOptions.DrawsAfterEndLocation);
                    }
                    else if (gradType == GradientType.Linear)
                    {
                        var startPoint = GradientEffectExtentions.GetStartPoint(element);
                        var endPoint = GradientEffectExtentions.GetEndPoint(element);

                        g.DrawLinearGradient(gradient, new CGPoint(startPoint.X, startPoint.Y), new CGPoint(endPoint.X, endPoint.Y), CGGradientDrawingOptions.DrawsAfterEndLocation | CGGradientDrawingOptions.DrawsBeforeStartLocation);
                    }
                }


                using (var im = UIGraphics.GetImageFromCurrentImageContext())
                using (var imageHolder = new UIImageView(im))
                {
                    Container.AddSubview(imageHolder);
                    Container.SendSubviewToBack(imageHolder);
                }
                UIGraphics.EndImageContext();
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

        nfloat[] GetFloatArrayFromColors(Color startColor, Color endColor)
        {
            var array = new nfloat[8];

            array[0] = new nfloat(startColor.R);
            array[1] = new nfloat(startColor.G);
            array[2] = new nfloat(startColor.B);
            array[3] = new nfloat(startColor.A);

            array[4] = new nfloat(endColor.R);
            array[5] = new nfloat(endColor.G);
            array[6] = new nfloat(endColor.B);
            array[7] = new nfloat(endColor.A);

            return array;
        }

        nfloat[] GetFloatArrayFromColors(IList<Color> colors)
        {
            var array = new nfloat[colors.Count * 4];

            for (int i = 0, arrayIndex = 0; i < colors.Count; i++, arrayIndex += 4)
            {
                array[arrayIndex] = new nfloat(colors[i].R);            
                array[arrayIndex + 1] = new nfloat(colors[i].G);
                array[arrayIndex + 2] = new nfloat(colors[i].B);
                array[arrayIndex + 3] = new nfloat(colors[i].A);
            }
            return array;
        }

        nfloat[] GetFloatArrayFromLocations(IList<double> locations)
        {
            var array = new nfloat[locations.Count];

            for (int i = 0; i < locations.Count; i++)
            {
                array[i] = new nfloat(locations[i]);
            }
            return array;
        }

    }
}

