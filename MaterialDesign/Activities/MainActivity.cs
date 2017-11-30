using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MaterialDesign.Adapters;
using MaterialDesign.Infrastucture.Transformers;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace MaterialDesign.Activities
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            SetupTabs();
            SetupToolbar();
        }

        private void SetupTabs()
        {
            var mainPageAdapter = new MainPageAdapter(SupportFragmentManager);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = mainPageAdapter;
            viewPager.SetPageTransformer(true, new ScaleTransformer());

            //Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, args) =>
            {
                Toast.MakeText(this, args.MenuItem.ItemId, ToastLength.Short).Show();

            };
            navigationView.InflateMenu(Resource.Menu.NavBarMenu);

            drawerLayout = (DrawerLayout)FindViewById<DrawerLayout>(Resource.Id.drawerLayout);


            //_navigationView.InflateHeaderView(Resource.Layout.MainToolbar);

            //// Create ActionBarDrawerToggle button and add it to the toolbar
            //var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            //drawerLayout.SetDrawerListener(drawerToggle);
            //drawerToggle.SyncState();

            ////Load default screen
            //var ft = FragmentManager.BeginTransaction();
            //ft.AddToBackStack(null);
            //ft.Add(Resource.Id.HomeFrameLayout, new HomeFragment());
            //ft.Commit();
        }

        private void SetupToolbar()
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Playing with Material Design";

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MenuMain, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;

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