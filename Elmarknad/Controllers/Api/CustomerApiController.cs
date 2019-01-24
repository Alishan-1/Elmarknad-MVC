using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Elmarknad.Controllers.Api
{
    [RoutePrefix("api/customer")]
    public class CustomerApiController : ApiController
    {
        private CustomerRepository _cust = new CustomerRepository();

        [Route("delete")]
        [HttpPost]
        public IHttpActionResult DeleteCustomer(List<string> id) {
            try
            {
                _cust.DeleteUser(int.Parse(id[0]));
                return Ok();
            }
            catch {
                return BadRequest();
            }
        }
    }
}
