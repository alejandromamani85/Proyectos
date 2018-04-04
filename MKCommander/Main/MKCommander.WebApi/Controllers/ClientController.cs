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

        [HttpGet]
        [Route("getAllConnections")]
        public IHttpActionResult GetAllConnections()
        {
            var result = Service.GetClientsAllConnections();
            return Json<List<QueueSimple>>(result);
        }

        [HttpGet]
        [Route("getAllCustom")]
        public IHttpActionResult GetAllCustom()
        {
            var result = Service.GetClientsAllConnections().OrderBy(x => x.Name).Select((x, index) => new { Index = index, x.Name, x.Target, x.Comment });
            return Json(new { Count = result.Count(), Result = result });
        }

        [HttpGet]
        [Route("getAllCustomFull")]
        public IHttpActionResult GetAllCustomFull()
        {
            var result = Service.GetClientsAllConnectionsFull();
            return Json(new { Count = result.Count(), Result = result });
        }

        [HttpGet]
        [Route("getFirewallAddressList")]
        public IHttpActionResult GetFirewallAddressList()
        {
            var result = Service.GetClientFirewallAddresList();
            return Json(new { Count = result.Count(), Result = result });
        }

        [HttpGet]
        [Route("getClientAllStatus")]
        public IHttpActionResult GetClientAllStatus()
        {
            var result = Service.GetClientAllStatus();
            return Json(new { Count = result.Count(), Result = result });
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
