using MKCommander.Logic.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tik4net.Objects.Queue;

namespace MKCommander.WebApi.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : BaseController<SrvClient>
    {
        // GET: api/Client
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            var result = Service.GetClientsAll();
            return Json<List<QueueSimple>>(result);
        }

        // POST: api/Client
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
