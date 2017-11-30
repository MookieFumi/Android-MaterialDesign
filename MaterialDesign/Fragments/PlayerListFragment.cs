using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MaterialDesign.Adapters;
using MaterialDesign.Infrastucture;
using MaterialDesign.Model;
using Newtonsoft.Json;
using Orientation = Android.Content.Res.Orientation;

namespace MaterialDesign.Fragments
{
    public class PlayerListFragment : Android.Support.V4.App.Fragment
    {
        public IEnumerable<Player> Players { get; private set; }

        public static PlayerListFragment NewInstance(IEnumerable<Player> players)
        {
            return new PlayerListFragment
            {
                Players = players ?? Enumerable.Empty<Player>()
            };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recuperamos las variables guardadas en OnSaveInstanceState
            var value = savedInstanceState?.GetString(Constants.TagPlayers, string.Empty);
            if (!string.IsNullOrEmpty(value))
                Players = JsonConvert.DeserializeObject<IEnumerable<Player>>(value);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.PlayerListFragment, container, false);
        }

        /// <summary>
        ///     Any view setup should occur here.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="savedInstanceState"></param>
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var adapter = new PlayerAdapter(Activity, Players.ToArray());
            adapter.PlayerClicked += (sender, player) =>
            {
                Toast.MakeText(Activity, player.Name, ToastLength.Short).Show();
            };

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(GetLayoutManager());
            recyclerView.SetAdapter(adapter);
        }

        private LinearLayoutManager GetLayoutManager()
        {
            if (Activity.IsTablet())
            {
                return new GridLayoutManager(Activity, GetItemsPerRow());
            }
            return new LinearLayoutManager(Activity, LinearLayoutManager.Vertical, false);
        }

        private int GetItemsPerRow()
        {
            return Activity.Resources.Configuration.Orientation == Orientation.Portrait ? 2 : 3;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            //Todas las variables locales las guardamos en el Bundle para posteriormente recuperarla en el OnCreate
            outState.PutString(Constants.TagPlayers, JsonConvert.SerializeObject(Players));

            base.OnSaveInstanceState(outState);
        }

    }
}