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

        public event EventHandler<Player> DetailClicked;

        protected virtual void OnDetailClicked(Player player)
        {
            DetailClicked?.Invoke(this, player);
        }

        public event EventHandler<Player> SelectionClicked;

        protected virtual void OnSelectionClicked(Player player)
        {
            SelectionClicked?.Invoke(this, player);
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

            Picasso.With(_context).Load(player.ImageUrl).Into(holder.ImageUrl);
            holder.Name.Text = player.Name;
            holder.Team.Text = player.Team;
            holder.DetailsButton.Click += (sender, args) =>
            {
                OnDetailClicked(player);
            };
            holder.SelectionButton.Click += (sender, args) =>
            {
                OnSelectionClicked(player);
            };
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
            view.Click += (sender, e) => onClick(base.AdapterPosition);

            ImageUrl = view.FindViewById<ImageView>(Resource.Id.image);
            Name = view.FindViewById<TextView>(Resource.Id.name);
            Team = view.FindViewById<TextView>(Resource.Id.team);

            DetailsButton = view.FindViewById<Button>(Resource.Id.detailsButton);
            SelectionButton = view.FindViewById<Button>(Resource.Id.selectionButton);
        }

        public ImageView ImageUrl { get; }
        public TextView Name { get; }
        public TextView Team { get; }
        public Button SelectionButton { get; }
        public Button DetailsButton { get; }
    }
}