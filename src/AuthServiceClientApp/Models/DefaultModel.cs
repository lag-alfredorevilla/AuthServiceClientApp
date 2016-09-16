using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServiceClientApp.Models
{
    public class DefaultModel
    {
        public IEnumerable<AuthProviderConfig> AuthProviders { get; set; }

    }
}
