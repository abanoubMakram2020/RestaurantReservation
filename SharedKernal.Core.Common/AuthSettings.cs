using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Core.Common
{
    public class AuthSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public string WebAudiance { get; set; }
        public string MobileAudiance { get; set; }
    }
}
