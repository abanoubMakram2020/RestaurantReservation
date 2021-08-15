using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Core.Common.Configuration
{
    public class DatabaseConfiguration
    {
        public static string ResturantReservationDBConnection { get; set; }
        public static string ResturantReservationIdentityDBConnection { get; set; }
        public static bool AllowDropRecreateDatabase { get; set; }
    }
}
