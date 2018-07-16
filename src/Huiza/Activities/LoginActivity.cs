using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App; //  material design 
using Android.Support.V7.Widget; 
using Android.Support.Design.Widget;
using Android.Content;
using Huiza.Presenters;
using System;


namespace Huiza.Activities
{
    [Activity(Label = "Huiza")]
    public class LoginActivity : AppCompatActivity
    {
        LoginPresenter loginPresenter;
        TextView register;
        AppCompatButton login;
        EditText email;
        EditText password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login);
            // busca por su codigo <Profesor> (aula.codigo.205)
            register = FindViewById<TextView>(Resource.Id.link_signup);
            login = FindViewById<AppCompatButton>(Resource.Id.btn_login);
            email = FindViewById<EditText>(Resource.Id.input_email);
            password = FindViewById<EditText>(Resource.Id.input_password);

            // cuando te hacen click = orden();
            loginPresenter = new LoginPresenter(this);

            login.Click += LoginClient;
            register.Click += RegisterClient;
            
        }
        public void RegisterClient(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(RegisterActivity));
            Finish();
            this.StartActivity(newActivity);
        }
        public void LoginClient(object sender, EventArgs args)
        {
            this.loginPresenter.Authentication(sender,args,email.Text,password.Text);
        }


    }
}

