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
using Huiza.Presenters;

namespace Huiza.Activities
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
        EditText password_confirmation;
        RegisterPresenter registerPresenter;
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
            password_confirmation = FindViewById<EditText>(Resource.Id.input_password_confirmation);

            this.registerPresenter = new RegisterPresenter(this);
            register.Click += RegisterClient;
            login.Click += loginClient;
        }

        public void loginClient(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(LoginActivity));
            Finish();
            this.StartActivity(newActivity);
        }
        public void RegisterClient(object sender, EventArgs args)
        {
            this.registerPresenter.Register(sender,args,email,password,name,password_confirmation, register);
        }
    }
}