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

namespace Huiza.Presenters
{
    public class CatalogProductPresenter
    {
        Context context;

        ApiService apiService = new ApiService();

        List<Product> listProduct;

        public CatalogProductPresenter(Context _context)
        {
            this.context = _context;
        }

        public async void LoadProducts(GridView gridViewProduct)
        {
 
            var response = await this.apiService.GetList<Product>(
            "http://comercialhuizaperu.com",
            "/api",
            "/products");
            this.listProduct = (List<Product>)response.Result;


            ProductAdapter productAdapter = new ProductAdapter(context, listProduct);
            gridViewProduct.Adapter = productAdapter;
            
        }
    }
}