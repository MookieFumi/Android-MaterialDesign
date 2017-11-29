using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MaterialDesign
{
    [Activity(Label = "MaterialDesign", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Playing with Material Design";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.MenuMain, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.search:
                    Toast.MakeText(this, "Search clicked", ToastLength.Short).Show();
                    break;
                case Resource.Id.help:
                    Toast.MakeText(this, "Help clicked", ToastLength.Short).Show();
                    break;
                case Resource.Id.about:
                    Toast.MakeText(this, "About clicked", ToastLength.Short).Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

