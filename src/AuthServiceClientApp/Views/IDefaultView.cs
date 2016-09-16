using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace AuthServiceClientApp.Views
{
    public class AuthorizeEventArgs : EventArgs
    {
        public AuthorizeEventArgs(string authProviderIndentity)
        {
            if (string.IsNullOrEmpty(authProviderIndentity))
                throw new ArgumentNullException("authProviderIndentity");

            this.AuthProviderIndentity = authProviderIndentity;
        }

        public string AuthProviderIndentity { get; private set; }
    }

    public interface IDefaultView : IView<Models.DefaultModel>
    {
        event EventHandler<AuthorizeEventArgs> Authorize;
    }
}
