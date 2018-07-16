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
using Huiza.Presenters;
using Android.Support.V7.App;

namespace Huiza.Activities
{
    [Activity(Label = "CatalogProductActivity")]
    public class CatalogProductActivity : AppCompatActivity
    {
        GridView gridViewCatalog;
        CatalogProductPresenter presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.catalog_product);

            gridViewCatalog = FindViewById<GridView>(Resource.Id.gridView1);

            presenter = new CatalogProductPresenter(this);

            presenter.LoadProducts(gridViewCatalog);
        }

    }
}