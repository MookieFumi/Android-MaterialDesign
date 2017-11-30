using System;
using Android.App;
using Android.Util;

namespace MaterialDesign.Infrastucture
{
    public static class Helper
    {
        public static bool IsTablet(this Activity activity)
        {
            var metrics = new DisplayMetrics();
            activity.WindowManager.DefaultDisplay.GetMetrics(metrics);

            var yInches = metrics.HeightPixels / metrics.Ydpi;
            var xInches = metrics.WidthPixels / metrics.Xdpi;
            var diagonalInches = Math.Sqrt(xInches * xInches + yInches * yInches);
            if (diagonalInches >= 6.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}