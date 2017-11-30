using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MaterialDesign.Adapters;
using MaterialDesign.Infrastucture.Transformers;

namespace MaterialDesign.Activities
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            SetupToolbar();
            SetupTabs();
        }

        private void SetupTabs()
        {
            var mainPageAdapter = new MainPageAdapter(SupportFragmentManager);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = mainPageAdapter;
            viewPager.SetPageTransformer(true, new ScaleTransformer());
        }

        private void SetupToolbar()
        {
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