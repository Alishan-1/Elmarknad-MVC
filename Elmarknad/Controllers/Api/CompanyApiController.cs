using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Elmarknad.Controllers.Api
{
    [RoutePrefix("api/company")]
    public class CompanyApiController : ApiController
    {
        private ClientRepository _client = new ClientRepository();
        private DealRepository _deal = new DealRepository();

        [Route("delete")]
        [HttpPost]
        public IHttpActionResult RemoveCompany(List<string> id) {
            try
            {
                _client.DeleteCompany(int.Parse(id[0]));
                return Ok();
            }
            catch {
                return BadRequest();
            }
        }
        [Route("deleteclient")]
        [HttpPost]
        public IHttpActionResult RemoveClient(List<string> id)
        {
            try
            {
                _deal.DeleteDeal(int.Parse(id[0]));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
