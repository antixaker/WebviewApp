using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace OpenGLGuide.Effects
{
    public class GradientEffect
    {
        #region Gradient effect

        public static readonly BindableProperty HasGradientProperty =
            BindableProperty.CreateAttached("HasGradient", typeof(bool), typeof(GradientEffect), false, propertyChanged: OnHasGradientChanged);

        private static void OnHasGradientChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
                return;
            var gradientEffect = Effect.Resolve("Takeda.GradientEffect");

            var hasBorder = (bool)newValue;
            if (hasBorder)
            {
                view.Effects.Add(gradientEffect);
            }
            else
            {
                if (view.Effects.Contains(gradientEffect))
                    view.Effects.Remove(gradientEffect);
            }
        }

        public static void SetHasGradient(BindableObject view, bool hasGradient)
        {
            view.SetValue(HasGradientProperty, hasGradient);
        }

        public static bool GetHasGradient(BindableObject view)
        {
            return (bool)view.GetValue(HasGradientProperty);
        }

        public static readonly BindableProperty FirstColorProperty =
            BindableProperty.CreateAttached("FirstColor", typeof(Color), typeof(GradientEffect), Color.Black);

        public static void SetFirstColor(BindableObject view, Color newColor)
        {
            view.SetValue(FirstColorProperty, newColor);
        }

        public static Color GetFirstColor(BindableObject view)
        {
            return (Color)view.GetValue(FirstColorProperty);
        }

        public static readonly BindableProperty SecondColorProperty =
            BindableProperty.CreateAttached("SecondColor", typeof(Color), typeof(GradientEffect), Color.Black);

        public static void SetSecondColor(BindableObject view, Color newColor)
        {
            view.SetValue(SecondColorProperty, newColor);
        }

        public static Color GetSecondColor(BindableObject view)
        {
            return (Color)view.GetValue(SecondColorProperty);
        }

        public static readonly BindableProperty TypeOfGradientProperty =
            BindableProperty.CreateAttached("TypeOfGradient", typeof(GradientType), typeof(GradientEffect), GradientType.Radial);

        public static void SetTypeOfGradient(BindableObject view, GradientType type)
        {
            view.SetValue(TypeOfGradientProperty, type);
        }

        public static GradientType GetTypeOfGradient(BindableObject view)
        {
            return (GradientType)view.GetValue(TypeOfGradientProperty);
        }


        public static readonly BindableProperty StartPointProperty =
            BindableProperty.CreateAttached("StartPoint", typeof(Point), typeof(GradientEffect), new Point(0, 0));

        public static void SetStartPoint(BindableObject view, Point point)
        {
            view.SetValue(StartPointProperty, point);
        }

        public static Point GetStartPoint(BindableObject view)
        {
            return (Point)view.GetValue(StartPointProperty);
        }

        public static readonly BindableProperty EndPointProperty =
            BindableProperty.CreateAttached("EndPoint", typeof(Point), typeof(GradientEffect), new Point(0, 0));

        public static void SetEndPoint(BindableObject view, Point point)
        {
            view.SetValue(EndPointProperty, point);
        }

        public static Point GetEndPoint(BindableObject view)
        {
            return (Point)view.GetValue(EndPointProperty);
        }

        public static readonly BindableProperty GradientCenterProperty =
            BindableProperty.CreateAttached("GradientCenter", typeof(Point), typeof(GradientEffect), new Point(0, 0));

        public static void SetGradientCenter(BindableObject view, Point center)
        {
            view.SetValue(GradientCenterProperty, center);
        }

        public static Point GetGradientCenter(BindableObject view)
        {
            return (Point)view.GetValue(GradientCenterProperty);
        }

        public static readonly BindableProperty GradientRadiusProperty =
            BindableProperty.CreateAttached("GradientRadius", typeof(int), typeof(GradientEffect), 0);

        public static void SetGradientRadius(BindableObject view, int radius)
        {
            view.SetValue(GradientRadiusProperty, radius);
        }

        public static int GetGradientRadius(BindableObject view)
        {
            return (int)view.GetValue(GradientRadiusProperty);
        }


        public static readonly BindableProperty ColorListProperty =
            BindableProperty.CreateAttached("ColorList", typeof(IList<Color>), typeof(GradientEffect), null);

        public static void SetColorList(BindableObject view, IList<Color> colors)
        {
            view.SetValue(ColorListProperty, colors);
        }

        public static IList<Color> GetColorList(BindableObject view)
        {
            return (IList<Color>)view.GetValue(ColorListProperty);
        }

        public static readonly BindableProperty LocationsListProperty =
            BindableProperty.CreateAttached("LocationsList", typeof(IList<double>), typeof(GradientEffect), null);

        public static void SetLocationsList(BindableObject view, IList<double> points)
        {
            view.SetValue(LocationsListProperty, points);
        }

        public static IList<double> GetLocationsList(BindableObject view)
        {
            return (IList<double>)view.GetValue(LocationsListProperty);
        }

        #endregion
    }

    public enum GradientType
    {
        Linear,
        Radial
    }

}

