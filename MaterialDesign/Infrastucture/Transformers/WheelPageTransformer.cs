using Android.Support.V4.View;
using Android.Views;

namespace MaterialDesign.Infrastucture.Transformers
{
    /// <summary>
    /// https://github.com/Martynnw/AndroidDemos/blob/1e3c4c8d0d96c617c5ff1447600c276bc5acfd3f/PagerDemo/PagerDemo/WheelPageTransformer.cs
    /// </summary>
    internal class WheelPageTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        private const float MaxAngle = 30F;

        public void TransformPage(View view, float position)
        {
            if (position < -1 || position > 1)
            {
                view.Alpha = 0; // The view is offscreen.
            }
            else
            {
                view.Alpha = 1;

                view.PivotY = view.Height / 2; // The Y Pivot is halfway down the view.

                // The X pivots need to be on adjacent sides.
                if (position < 0)
                {
                    view.PivotX = view.Width;
                }
                else
                {
                    view.PivotX = 0;
                }

                view.RotationY = MaxAngle * position; // Rotate the view.
            }
        }
    }
}