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

namespace Huiza.Adapters
{
    class ProductAdapter : BaseAdapter<Product>
    {

        Context context;
        List<Product> list;

        public ProductAdapter(Context context, List<Product> _list)
        {
            this.context = context;
            this.list = _list;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ProductAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ProductAdapterViewHolder;

            if (holder == null)
            {
                holder = new ProductAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.adapter_product, parent, false);
                holder.Name = view.FindViewById<TextView>(Resource.Id.textViewName);
                holder.Price = view.FindViewById<TextView>(Resource.Id.textViewPrice);

                view.Tag = holder;
            }


            //fill in your items
            holder.Name.Text = list[position].name;
            holder.Price.Text = "S/." + list[position].price.ToString();

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return list.Count;
            }
        }
        public override Product this[int position]
        {
            get
            {
                return list[position];
            }
        }

    }

    class ProductAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Name { get; set; }
        public TextView Price { get; set; }
        public ImageView Image { get; set; }
    }
}