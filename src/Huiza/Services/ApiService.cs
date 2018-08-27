namespace Huiza.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    using System.Net.Http;
    using Newtonsoft.Json;
    //using Plugin.Connectivity;
    

    public class ApiService
    {
        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<TokenResponse> GetToken(
            string urlBase,
            string email,
            string password)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/auth/login",
                    new StringContent(string.Format(
                    "email={0}&password={1}",
                    email, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(
                    resultJSON);
                return result;
            }
            catch
            {
                return null;
            }
        }
        /*
        public async Task<Response> GetTokenCulqui(
            string card_number,
            string cvv,
            string expiration_month,
            string expiration_year,
            string email)
                {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                  new AuthenticationHeaderValue("Bearer", "sk_test_Km1vANGLrdAE8jKm");
                Cart card = new Cart(card_number, cvv, expiration_month, expiration_year, email);

                client.BaseAddress = new Uri("https://api.culqi.com");
                var response = await client.PostAsync("/v2/tokens",
                    new StringContent(JsonConvert.SerializeObject(card),
                    Encoding.UTF8, "application/json"));

                var resultJSON = await response.Content.ReadAsStringAsync();
        

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = resultJSON,
                    };
                }

                var result = JsonConvert.DeserializeObject<TokenResponse>(resultJSON);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = result,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        */

        public async Task<TokenResponse> GetTokenRegister(
            string urlBase,
            string email,
            string password,
            string name)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("/api/auth/register",
                    new StringContent(string.Format(
                    "email={0}&password={1}&name={2}",
                    email, password,name),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(
                    resultJSON);
                return result;
            }
            catch
            {
                return null;
            }
        }




    }
}