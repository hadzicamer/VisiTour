using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Model;
using Xamarin.Forms;

namespace VisiTour.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Customers Customers { get; set; }
        public static Flights Flights { get; set; }



        private string _route;

#if DEBUG
        private string _APIurl = "http://localhost:62999/api";
#endif
#if RELASE
        private string _APIurl = "https://mywebsite.azure.com/api";
#endif
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_APIurl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");
            throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_APIurl}/{_route}/{id}";

            var res = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return res;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_APIurl}/{_route}";
            try
            {
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                var stringbuilder = new StringBuilder();
                foreach (var error in err)
                    stringbuilder.Append($"{error.Key},${string.Join(",", error.Value)}");

                await Application.Current.MainPage.DisplayAlert("Greška", stringbuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
            var url = $"{_APIurl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                var stringbuilder = new StringBuilder();
                foreach (var error in err)
                    stringbuilder.Append($"{error.Key},${string.Join(",", error.Value)}");

                await Application.Current.MainPage.DisplayAlert("Greška", stringbuilder.ToString(), "OK");
                return default(T);
            }
        }
    }
}

