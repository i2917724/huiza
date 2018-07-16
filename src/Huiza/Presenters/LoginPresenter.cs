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
using Huiza.Services;
using Huiza.Activities;

namespace Huiza.Presenters
{
    public class LoginPresenter
    {
        Context context;

        ApiService apiService = new ApiService();
        public LoginPresenter(Context _context)
        {
            this.context = _context;
        }

        public async void Authentication(object sender, EventArgs args,string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Correo vacío");

                builder.Create().Show();
                return;
            }
            if (!IsValidEmail(email))
            {

                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Email no valido");

                builder.Create().Show();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("Contraseña vacía");

                builder.Create().Show();
                return;
            }

            if (password.Length < 6)
            {
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage("La contraseña debe ser mayor a 6 caracteres");

                builder.Create().Show();
                return;
            }


            var tokenResponse = await apiService.GetToken("http://comercialhuizaperu.com",email,password);

            if (tokenResponse.error != null)
            {
                
                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);

                builder.SetTitle("Error")
                       .SetMessage(tokenResponse.error);

                builder.Create().Show();
                return;
                
            }

            Intent intent = new Intent(context, typeof(CatalogProductActivity));
            ((LoginActivity)(context)).Finish();
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