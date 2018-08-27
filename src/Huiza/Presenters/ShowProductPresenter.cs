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

namespace Huiza.Presenters
{
    public class ShowProductPresenter
    {
        Context context;
        public ShowProductPresenter(Context _context)
        {
            this.context = _context;
        }

        public void RenderProduct(Product product,TextView name,TextView category,
            TextView description,ImageView image)
        {
            name.Text = product.name;
            category.Text = product.category.name;

            description.Text = product.description;
            Picasso.With(context)
                  .Load(product.image)
                  .Into(image);
        }
    }
}