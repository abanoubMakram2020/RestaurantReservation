using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.Core.Common.Enum
{
    public class HttpEnum
    {

        /// <summary>
        /// 
        /// </summary>
        public enum ResponseStatusCode
        {
            [EnumMessage("تمت العمليه بنجاح")]
            Successfully = 1,
            [EnumMessage("لا نوجد بيانات")]
            NotFound = 2,
            [EnumMessage("العملية غير صالحة")]
            NotAccept = 3,
            [EnumMessage("خطأ, برجاء التأكد من البيانات")]
            MultiError = 4,
            [EnumMessage("حركة غير صالحة")]
            MoveNotAccept = 5,
            [EnumMessage("خطأ في النظام")]
            SystemInternalError = 6,
            [EnumMessage("تكرار في البيانات")]
            Dublicate = 7,
            [EnumMessage("خطأ في البيانات")]
            InvalidData = 8
        }

        public enum HttpMethod
        {
            [EnumMessage("GET")]
            Get,
            [EnumMessage("POST")]
            Post,
            [EnumMessage("PUT")]
            Put,
            [EnumMessage("DELETE")]
            Delete
        }
        public enum HttpContentType
        {
            [EnumMessage("text/plain")]
            Text,
            [EnumMessage("text/html")]
            HTML,
            [EnumMessage("application/json")]
            JSON,
            [EnumMessage("application/javascript")]
            JavaScript,
            [EnumMessage("application/xml")]
            XML
        }
    }
}
