using AuthService;
using AuthServiceClientApp.Models;
using AuthServiceClientApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebFormsMvp;

namespace AuthServiceClientApp.Presenters
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        public DefaultPresenter(IDefaultView view) : base(view)
        {
            this.View.Load += View_Load;
            this.View.Authorize += View_Authorize;
        }

        private void View_Load(object sender, EventArgs e)
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                HttpClient client = new HttpClient();
                var uri = "http://localhost:5000/auth/providers/";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                var result = client.GetStringAsync(uri).RunAsyncTask();
                var providerList = JsonConvert.DeserializeObject<IEnumerable<AuthProviderConfig>>(result);
                this.View.Model.AuthProviders = providerList;
            }
        }

        private void View_Authorize(object sender, AuthorizeEventArgs e)
        {
            HttpClient client = new HttpClient();
            var uri = $"http://localhost:5000/auth/providers/{e.AuthProviderIndentity}/request/";
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            var result = client.GetStringAsync(uri).RunAsyncTask();
            var authRequest = JsonConvert.DeserializeAnonymousType(result, new { Url = string.Empty });
            this.Response.Redirect(authRequest.Url, true);
        }


    }
}