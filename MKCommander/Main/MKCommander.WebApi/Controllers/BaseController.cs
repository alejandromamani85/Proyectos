using MKCommander.Logic.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MKCommander.WebApi.Controllers
{
    public class BaseController<TService> : ApiController where TService : SrvBase, new()
    {
        #region Properties

        protected TService Service { get; set; }
        #endregion

        #region Constructors

        public BaseController()
        {
            this.Service = new TService();
        }
        #endregion
    }
}
