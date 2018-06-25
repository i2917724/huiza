using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App; //  material design 
using Android.Support.V7.Widget; 
using Android.Support.Design.Widget;
using Android.Content;

using System;
using Huiza.Activitys;


namespace Huiza
{
    [Activity(Label = "Huiza")]
    public class LoginActivity : AppCompatActivity
    {
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
            login.Click += loginClient;
            register.Click += registerClient;
            
        }
        public void registerClient(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this, typeof(RegisterActivity));
            Finish();
            this.StartActivity(newActivity);
        }

        public void loginClient(object sender, EventArgs args)
        {

            if(string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text)) //validate empty fields 
            {
                Snackbar.Make(login, "Campos vacíos!", Snackbar.LengthLong)
                                .Show();

            }
            else if(email.Text != "huiza@gmail.com" || password.Text != "123456") //validate user
            {
                Snackbar.Make(login, "Usuario no válido!", Snackbar.LengthLong)
                      .Show();
            }
            else if(email.Text == "huiza@gmail.com" && password.Text == "123456") // Success
            {
                Intent newActivity = new Intent(this, typeof(CatalogProductActivity));
                Finish(); // matate
                this.StartActivity(newActivity);
            }
            else // Error
            {
                Snackbar.Make(login, "Ups ocurrió un error!", Snackbar.LengthLong)
                            .Show();
            }

        }
    }
}

