using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Java.Lang;
using MaterialDesign.Fragments;
using MaterialDesign.Services;

namespace MaterialDesign.Adapters
{
    public class MainPageAdapter : FragmentPagerAdapter
    {
        private readonly List<MainPageTab> _tabs;
        public MainPageAdapter(FragmentManager fragmentManager) : base(fragmentManager)
        {
            var players = new PlayersServices().GetPlayers().ToList();
            _tabs = new List<MainPageTab>
            {
                new MainPageTab(PlayerListFragment.NewInstance(players), "All players") ,
                new MainPageTab(PlayerListFragment.NewInstance(players.Where(p =>p.Country.Equals("Spain", StringComparison.InvariantCultureIgnoreCase))), "Spanish players"),
                new MainPageTab(PlayerListFragment.NewInstance(players.Where(p =>p.Country.Equals("United States", StringComparison.InvariantCultureIgnoreCase))),"USA players")
            };
        }

        public override int Count => _tabs.Count;

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_tabs.ElementAt(position).Title.ToUpper());
        }

        public override Fragment GetItem(int position)
        {
            return _tabs.ElementAt(position).Fragment;
        }

        public class MainPageTab
        {
            public MainPageTab(Fragment fragment, string title)
            {
                Fragment = fragment;
                Title = title;
            }

            public Fragment Fragment { get; }
            public string Title { get; }
        }
    }
}