using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Huiza.Activities;
using Huiza.Services;

namespace Huiza.Presenters
{
    public class RegisterPresenter
    {
        Context context;

        ApiService apiService = new ApiService();
        public RegisterPresenter(Context _context)
        {
            this.context = _context;
        }

        public async void Register(object sender, EventArgs args, EditText email, EditText password, EditText name, EditText password_confirmation, AppCompatButton register)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Correo vacío");

                builder.Create().Show();
                return;
            }
            if (!IsValidEmail(email.Text))
            {

                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Email no valido");

                builder.Create().Show();
                return;
            }

            if (string.IsNullOrEmpty(name.Text))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Nombre vacío");

                builder.Create().Show();
                return;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Contraseña vacía");

                builder.Create().Show();
                return;
            }
            if (password.Text.Length < 6)
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("La contraseña debe ser mayor a 6 caracteres");

                builder.Create().Show();
                return;
            }

            if (!password_confirmation.Text.Equals(password.Text))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Las contraseñas no coinciden");

                builder.Create().Show();
                return;
            }



            register.Text = "Cargando..";
            var tokenResponse = await apiService.GetTokenRegister("http://comercialhuizaperu.com", email.Text, password.Text, name.Text);
            register.Text = "Crear una cuenta";

            if (tokenResponse.error != null)
            {
                name.Text = "";
                email.Text = "";
                password.Text = "";
                password_confirmation.Text = "";

                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Success")
                       .SetMessage(tokenResponse.error);

                builder.Create().Show();
                return;
            }


            Intent intent = new Intent(context, typeof(CatalogProductActivity));
            ((RegisterActivity)(context)).Finish();
            this.context.StartActivity(intent);

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



    }
}