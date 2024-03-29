﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using ExpenseWireDesktopUI.Models;
using ExpenseWireDesktopUI.Library.Models;

namespace ExpenseWireDesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient;
        private ILoggedInUserModel _loggedInUserModel;

        public HttpClient ApiClient
        {
            get { return _apiClient; }
        }
        public APIHelper(ILoggedInUserModel loggedInUserModel)
        {
            InitializeClient();
            _loggedInUserModel = loggedInUserModel;
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    AuthenticatedUser authenticatedUser = JsonConvert.DeserializeObject<AuthenticatedUser>(result);
                    return authenticatedUser;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedInUserModel.CreatedDate = result.CreatedDate;
                    _loggedInUserModel.Id = result.Id;
                    _loggedInUserModel.FirstName = result.FirstName;
                    _loggedInUserModel.LastName = result.LastName;
                    _loggedInUserModel.Token = result.Token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
