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
using System.Threading.Tasks;
using Huiza.Activities;
using Huiza.Models;
using Newtonsoft.Json;

namespace Huiza
{
    [Activity(Label = "Comercial Huiza", Theme = "@style/MyThemeSplash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        private ISharedPreferences SessionCartHuiza;
        private Cart myCart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //cart comercial huiza
            myCart = new Cart();
            SessionCartHuiza = Application.Context.GetSharedPreferences("SessionCartHuiza", FileCreationMode.Private);

            if (SessionCartHuiza == null)
            {
                myCart = JsonConvert.DeserializeObject<Cart>(SessionCartHuiza.GetString("Cart", null));      
                var cart = SessionCartHuiza.Edit();
                cart.PutString("Cart", JsonConvert.SerializeObject(myCart));
                cart.Commit();
            }
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Desabilitamos que el usuario vuelva atras
        public override void OnBackPressed() { }

        // Espera 1 segundos
        async void SimulateStartup()
        {
            //Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(1000);
            //Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
        }
    }
}