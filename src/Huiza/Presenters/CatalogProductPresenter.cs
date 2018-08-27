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
using Huiza.Activities;
using Huiza.Models;
using Huiza.Services;
using Huiza.Adapters;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;

namespace Huiza.Presenters
{
    public class CatalogProductPresenter
    {
        Context context;
        Activity activity;

        ApiService apiService = new ApiService();

        List<Product> listProduct;

        public CatalogProductPresenter(Context _context,Activity _activity)
        {
            this.context = _context;
            this.activity = _activity;
        }

        public async void LoadProducts(RecyclerView recyclerViewProduct)
        {
 
            var response = await this.apiService.GetList<Product>(
            "http://comercialhuizaperu.com",
            "/api",
            "/products");
            this.listProduct = (List<Product>)response.Result;

            recyclerViewProduct.SetLayoutManager(new GridLayoutManager(context, 2));

            ProductAdapter productAdapter = new ProductAdapter(activity, listProduct);
            recyclerViewProduct.SetAdapter(productAdapter);

        }
         public void ChangeItems(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
         {
            switch (e.Item.ItemId)
            {
                case Resource.Id.navigation_home:
                    Toast.MakeText(context, "Action Add sd", ToastLength.Short).Show();
                    break;
            }
         }
    }
}