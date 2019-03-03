using Elmarknad.Models.ViewModels;
using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Elmarknad.Controllers.Api
{
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        private SearchResultRepository _Search = new SearchResultRepository();

        [Route("rating")]
        [HttpPost]
        public IHttpActionResult FilterByRating(List<string> items)
        {
            try
            {
                var model = _Search.FilterByRating(int.Parse(items[0]), items[1], int.Parse(items[2]));

                return Ok(model);
            }
            catch
            {

                return BadRequest();
            }

        }
        [Route("price")]
        [HttpPost]
        public IHttpActionResult FilterByPrice(List<string> items)
        {
            try
            {
                var model = _Search.FilterByPrice(int.Parse(items[0]), items[1], int.Parse(items[2]));

                return Ok(model);
            }
            catch
            {

                return BadRequest();
            }

        }
        [Route("area")]
        [HttpGet]
        public IHttpActionResult GetArea(string Postnumber)
        {
            try
            {
                Regex regex = new Regex(@"^\d{3}\d{2}$");
                Match match = regex.Match(Postnumber);
                if (match.Success)
                {
                    var model = _Search.GetElområdeId(int.Parse(Postnumber));

                    return Ok(model);
                }else
                {
                    return BadRequest();
                }
                
            }
            catch
            {

                return BadRequest();
            }

        }
    }
}
