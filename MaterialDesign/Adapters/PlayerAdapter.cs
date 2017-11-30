using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MaterialDesign.Model;
using Square.Picasso;

namespace MaterialDesign.Adapters
{
    public class PlayerAdapter : RecyclerView.Adapter
    {
        private readonly Context _context;
        private readonly Player[] _players;

        public event EventHandler<Player> PlayerClicked;

        protected virtual void OnPlayerClicked(Player player)
        {
            PlayerClicked?.Invoke(this, player);
        }

        public PlayerAdapter(Context context, Player[] players)
        {
            _context = context;
            _players = players;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var player = _players[position];

            var holder = viewHolder as PlayerHolder;
            holder.Name.Text = player.Name;
            holder.Team.Text = player.Team;
            Picasso.With(_context).Load(player.ImageUrl).Into(holder.ImageUrl);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PlayerListViewRow, parent, false);
            return new PlayerHolder(itemView, position =>
            {
                var player = _players[position];
                OnPlayerClicked(player);
            });
        }

        public override int ItemCount => _players.Length;
    }

    public class PlayerHolder : RecyclerView.ViewHolder
    {
        public PlayerHolder(View view, Action<int> onClick) : base(view)
        {
            ImageUrl = view.FindViewById<ImageView>(Resource.Id.image);
            Name = view.FindViewById<TextView>(Resource.Id.name);
            Team = view.FindViewById<TextView>(Resource.Id.team);
            view.Click += (sender, e) => onClick(base.AdapterPosition);
        }

        public ImageView ImageUrl { get; private set; }
        public TextView Name { get; private set; }
        public TextView Team { get; private set; }
    }
}