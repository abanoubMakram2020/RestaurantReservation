using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Core.Common;
using SharedKernal.Middlewares.Basees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route(APIRoute.VersioningTemplate)]
    public class BaseController : ControllerBase
    {
        #region Properties
        public Presenter _Presenter; //{ get; set; }
        //protected ITokenHandler TokenHandler { get; }
        #endregion

        #region Constructor
        public BaseController(Presenter Presenter)
        {
            _Presenter = Presenter;
        }
        #endregion

        #region Methods
        //[NonAction]
        //public int GetCurrentUserId()
        //{
        //    List<Claim> result = TokenHandler.GetTokenData(Request);
        //    return int.TryParse(result.FirstOrDefault(item => item.Type.Equals("sub", System.StringComparison.Ordinal)).Value, out int userId) ? userId : default;
        //}
        #endregion
    }
}
