using System;
using System.Linq;
using Android.Support.V4.App;
using Java.Lang;
using MaterialDesign.Fragments;
using MaterialDesign.Services;

namespace MaterialDesign.Adapters
{
    public class MainPageAdapter : FragmentPagerAdapter
    {
        public MainPageAdapter(FragmentManager fragmentManager) : base(fragmentManager)
        {
        }

        public override int Count => 3;

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            var title = string.Empty;

            switch (position)
            {
                case 0:
                    title = "All players";
                    break;
                case 1:
                    title = "USA players";
                    break;
                case 2:
                    title = "Spanish players";
                    break;
            }

            return new Java.Lang.String(title.ToUpper());
        }

        public override Fragment GetItem(int position)
        {
            var players = new PlayersServices().GetPlayers();

            switch (position)
            {
                case 0:
                    return PlayerListFragment.NewInstance(players);
                case 1:
                    return PlayerListFragment.NewInstance(players.Where(p => p.Country.Equals("United States", StringComparison.InvariantCultureIgnoreCase)));
                case 2:
                    return PlayerListFragment.NewInstance(players.Where(p => p.Country.Equals("Spain", StringComparison.InvariantCultureIgnoreCase)));
                default:
                    return null;
            }
        }
    }
}