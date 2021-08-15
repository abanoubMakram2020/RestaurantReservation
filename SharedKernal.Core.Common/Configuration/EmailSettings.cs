using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Core.Common.Configuration
{
    public class EmailSettings
    {
        public static string EmailAddress { get; set; }
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost     { get; set; }
        public static int    GmailPort     { get; set; }
        public static bool   GmailSSL       { get; set; }

    }
}
