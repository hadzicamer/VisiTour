﻿using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Model;

namespace VisiTour.WinUI
{
    public class APIService
    {
        //public static string Email { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            var res = await url.WithBasicAuth(Username,Password).GetJsonAsync<T>();
            return res;
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            var res = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return res;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            var res = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            return res;
        }

        public async Task<T> Update<T>(object id,object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var res = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            return res;
        }
    }
}
