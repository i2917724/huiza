using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

using Android.Support.Design.Widget; //material design google 
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Huiza.Activitys
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : AppCompatActivity
    {
        // var

        TextView login;
        AppCompatButton register;
        EditText name;
        EditText email;
        EditText password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.register);

            login = FindViewById<TextView>(Resource.Id.link_login);
            register = FindViewById<AppCompatButton>(Resource.Id.btn_register);
            name = FindViewById<EditText>(Resource.Id.input_name);
            email = FindViewById<EditText>(Resource.Id.input_email);
            password = FindViewById<EditText>(Resource.Id.input_password);

            register.Click += registerClient;
            login.Click += loginClient;
        }

        public void loginClient(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(LoginActivity));
            Finish();
            this.StartActivity(newActivity);
        }
        public void registerClient(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(email.Text) || 
                string.IsNullOrEmpty(password.Text) || 
                string.IsNullOrEmpty(name.Text)) //validate empty fields 
            {
                Snackbar.Make(register, "Campos vacíos!", Snackbar.LengthLong)
                                .Show();
            }
            else
            {
                Intent newActivity = new Intent(this, typeof(CatalogProductActivity));
                Finish();
                this.StartActivity(newActivity);
            }

        }
    }
}