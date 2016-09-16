using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthServiceClientApp.Models
{
    public enum Grants
    {
        AuthorizationCode,
        Implicit,
        ResourceOwnerPasswordCredentials,
        ClientCredentials
    }
}