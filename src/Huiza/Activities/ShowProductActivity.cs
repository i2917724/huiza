using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Huiza.Models;
using Newtonsoft.Json;
using Huiza.Presenters;

namespace Huiza.Activities
{
    [Activity(Label = "ShowProductActivity")]
    public class ShowProductActivity : AppCompatActivity
    {
        private Product product;
        private ShowProductPresenter showProductPresenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.show_product);

            product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("product"));

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            var txtName = FindViewById<TextView>(Resource.Id.textViewName);
            var txtCategory = FindViewById<TextView>(Resource.Id.textViewCategory);
            var txtDescription = FindViewById<TextView>(Resource.Id.textViewDescription);
            var cover = FindViewById<ImageView>(Resource.Id.imageViewCover);

            showProductPresenter = new ShowProductPresenter(this);
            showProductPresenter.RenderProduct(product,txtName,txtCategory,txtDescription,cover);

            toolbar.Title = "S/." + product.price.ToString();
            SetSupportActionBar(toolbar);
            if (SupportActionBar != null)
            { 
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

            // Create your application here
        }
    }
}