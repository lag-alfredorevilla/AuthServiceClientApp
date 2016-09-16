#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthServiceClientApp.Models;
using System.Net.Http;
using AuthServiceClientApp.Views;
using WebFormsMvp.Web;
#endregion

namespace AuthServiceClientApp
{
    public partial class Default : MvpPage<DefaultModel>, IDefaultView
    {

        protected void OnAuthorize(string authProviderIndentity)
        {
            this.Authorize?.Invoke(this, new AuthorizeEventArgs(authProviderIndentity: authProviderIndentity));
        }

        public event EventHandler<AuthorizeEventArgs> Authorize;

        protected void authProvidersRepeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Login")
            {
                var identity = (string)e.CommandArgument;
                this.OnAuthorize(identity);
            }
        }

        protected string GetAuthProviderDisplayName(AuthProviderConfig config, string language_code = "en")
        {
            if (!config.DisplayName.ContainsKey(language_code))
            {
                return config.DisplayName.First().Value;
            }
            return config.DisplayName[language_code];            
        }
    }
}