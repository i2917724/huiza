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
using Android.Support.Design.Widget;
using Newtonsoft.Json;
using Android.Support.V7.Widget;

namespace Huiza.Activities
{
    [Activity(Label = "CatalogProductActivity")]
    public class CatalogProductActivity : AppCompatActivity
    {
        RecyclerView recyclerViewCatalog;
        CatalogProductPresenter presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.catalog_product);

            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            recyclerViewCatalog = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            presenter = new CatalogProductPresenter(this,this);

            presenter.LoadProducts(recyclerViewCatalog);
            bottomNavigation.NavigationItemSelected += presenter.ChangeItems;

            //gridViewCatalog.ItemClick += ClickItemGrid;
        }

        /*
        void ClickItemGrid(object sender, AdapterView.ItemClickEventArgs e)
        {
           Intent intent = new Intent(this, typeof(ShowProductActivity));
             this.product = gridViewCatalog[e.Position];

           intent.PutExtra("product", JsonConvert.SerializeObject(this.product));
            this.StartActivity(intent);
        }*/



}
}