using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Huiza.Models;
using Square.Picasso;
using Android.Support.V7.Widget;
using Huiza.Activities;
using Newtonsoft.Json;

namespace Huiza.Adapters
{
    public class ProductViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public TextView txtName { get; set; }
        public TextView txtPrice { get; set; }
        public ImageView imageViewCover { get; set; }
        private IItemClickListenener itemClickListener;

        public ProductViewHolder(View itemView) : base(itemView)
        {
            txtName = itemView.FindViewById<TextView>(Resource.Id.title);
            txtPrice = itemView.FindViewById<TextView>(Resource.Id.price);
            imageViewCover = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);
            itemView.SetOnClickListener(this);

        }
        public void SetItemClickListener(IItemClickListenener itemClickListener)
        {
            this.itemClickListener = itemClickListener;
        }

        public void OnClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition);
        }
    }

    public class ProductAdapter : RecyclerView.Adapter, IItemClickListenener
    {

        private List<Product> lsProduct = new List<Product>();
        private Activity activity;
        public ProductAdapter(Activity activity, List<Product> lsProduct)
        {
            this.activity = activity;
            this.lsProduct = lsProduct;
        }

        public override int ItemCount
        {
            get
            {
                return lsProduct.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductViewHolder vh = holder as ProductViewHolder;
            vh.txtName.Text = lsProduct[position].name;
            vh.txtPrice.Text = "S/." + lsProduct[position].price.ToString();

            Picasso.With(activity)
                .Load(lsProduct[position].image)
                .Into(vh.imageViewCover);
            vh.SetItemClickListener(this);
        }
        public void OnClick(View itemView, int position)
        {
            Intent intent = new Intent(activity, typeof(ShowProductActivity));
            var product = lsProduct[position];

            intent.PutExtra("product", JsonConvert.SerializeObject(product));
            activity.StartActivity(intent);
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.adapter_product, parent, false);
            return new ProductViewHolder(view);
        }
    }
}