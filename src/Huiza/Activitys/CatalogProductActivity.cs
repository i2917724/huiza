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
using Huiza.Adapters;

namespace Huiza.Activitys
{
    [Activity(Label = "CatalogProductActivity")]
    public class CatalogProductActivity : Activity
    {
        ListView listViewCatalog;
        List<Product> productList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.catalog_product);

            listViewCatalog = FindViewById<ListView>(Resource.Id.listViewProducts);

            productList = new List<Product>() {
                new Product(){name = "Bicleta Montañera",price=150 },
                new Product(){name = "Bicleta Niños",price=100 },
                new Product(){name = "Bicleta Electrica",price=250 },
                new Product(){name = "Te la comes enterita",price=350},

            };

            ProductAdapter productAdapter = new ProductAdapter(this, productList);
            listViewCatalog.Adapter = productAdapter;
        }
    }
}