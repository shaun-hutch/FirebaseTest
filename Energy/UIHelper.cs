using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Energy
{
    public static class UIHelper
    {
        public static void SetBarColours(this Activity activity, Color colour)
        {
            activity.ActionBar.SetBackgroundDrawable(new ColorDrawable(colour));
            activity.Window.SetStatusBarColor(colour.Darken());
        }

        public static Color Darken(this Color colour, double factor = 0.7)
        {
            return Color.Rgb((int)(Color.GetRedComponent(colour) * factor), (int)(Color.GetGreenComponent(colour) * factor), (int)(Color.GetGreenComponent(colour) * factor));
        }

    }
}