using Elmarknad.Models;
using Elmarknad.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Elmarknad.Models.Webscrape;

namespace Elmarknad.Controllers.Api
{
    [RoutePrefix("api/scrape")]
    public class ScrapeApiController : ApiController
    {
        public ElområdeRepository ElJson = new ElområdeRepository();
        public ScrapeRepository Scrape = new ScrapeRepository();
        public DbEl db = new DbEl();
        //----------------------------------------------------------------------------------------------------------------------------
        //RÖRLIGTAVTAL
        //----------------------------------------------------------------------------------------------------------------------------
        public const string Rörligt2000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=2000&postnr=93149";
        public const string Rörligt2000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=2000&postnr=90328";
        public const string Rörligt2000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=2000&postnr=70234";
        public const string Rörligt2000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=2000&postnr=21129";

        public const string Rörligt5000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=5000&postnr=93149";
        public const string Rörligt5000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=5000&postnr=90328";
        public const string Rörligt5000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=5000&postnr=70234";
        public const string Rörligt5000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=5000&postnr=21129";

        public const string Rörligt20000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=20000&postnr=93149";
        public const string Rörligt20000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=20000&postnr=90328";
        public const string Rörligt20000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=20000&postnr=70234";
        public const string Rörligt20000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=9&forbrukning=20000&postnr=21129";
        //----------------------------------------------------------------------------------------------------------------------------
        //FASTAVTAL
        //----------------------------------------------------------------------------------------------------------------------------
        public const string Fast2000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=2000&postnr=93149";
        public const string Fast2000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=2000&postnr=90328";
        public const string Fast2000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=2000&postnr=70234";
        public const string Fast2000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=2000&postnr=21129";

        public const string Fast5000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=5000&postnr=93149";
        public const string Fast5000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=5000&postnr=90328";
        public const string Fast5000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=5000&postnr=70234";
        public const string Fast5000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=5000&postnr=21129";

        public const string Fast20000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=20000&postnr=93149";
        public const string Fast20000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=20000&postnr=90328";
        public const string Fast20000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=20000&postnr=70234";
        public const string Fast20000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=2&forbrukning=20000&postnr=21129";
        //----------------------------------------------------------------------------------------------------------------------------
        //MIXAVTAL
        //----------------------------------------------------------------------------------------------------------------------------
        public const string Mix2000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=2000&postnr=93149";
        public const string Mix2000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=2000&postnr=90328";
        public const string Mix2000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=2000&postnr=70234";
        public const string Mix2000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=2000&postnr=21129";

        public const string Mix5000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=5000&postnr=93149";
        public const string Mix5000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=5000&postnr=90328";
        public const string Mix5000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=5000&postnr=70234";
        public const string Mix5000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=5000&postnr=21129";

        public const string Mix20000Elområde1 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=20000&postnr=93149";
        public const string Mix20000Elområde2 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=20000&postnr=90328";
        public const string Mix20000Elområde3 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=20000&postnr=70234";
        public const string Mix20000Elområde4 = "https://www.ei.se/sv/Elpriskollen/Avtal/?avtalstypid=13&forbrukning=20000&postnr=21129";

        [Route("numbers")]
        [HttpPost]
        public IHttpActionResult UpdateNumbers(List<string> list) {
            try
            {
                
                ElJson.UpdateJsonFromFile();
                return Ok();
            }
            catch {

                return BadRequest();
            }

        }
  


     
        //Update Rörligt 2000kwh Elområde 1-4
        [Route("r2000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> R2000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Rörligt", 2000, Rörligt2000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Rörligt", 2000, Rörligt2000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Rörligt", 2000, Rörligt2000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Rörligt", 2000, Rörligt2000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }

        //Update Rörligt 5000kwh Elområde 1-4
        [Route("r5000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> R5000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Rörligt", 5000, Rörligt5000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Rörligt", 5000, Rörligt5000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Rörligt", 5000, Rörligt5000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Rörligt", 5000, Rörligt5000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }

        //Update Rörligt 20000kwh Elområde 1-4
        [Route("r20000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> R20000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Rörligt", 20000, Rörligt20000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Rörligt", 20000, Rörligt20000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Rörligt", 20000, Rörligt20000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Rörligt", 20000, Rörligt20000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }
       // -----------------------------------------------------------------------------------------------------------------------------------------------//
        //Update Fast 2000kwh Elområde 1-4
        [Route("f2000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> F2000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Fast", 2000, Fast2000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Fast", 2000, Fast2000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Fast", 2000, Fast2000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Fast", 2000, Fast2000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }

        //Update Fast 5000kwh Elområde 1-4
        [Route("f5000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> F5000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Fast", 5000, Fast5000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Fast", 5000, Fast5000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Fast", 5000, Fast5000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Fast", 5000, Fast5000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }

        //Update Fast 20 000kwh Elområde 1-4
        [Route("f20000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> F20000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Fast", 20000, Fast20000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Fast", 20000, Fast20000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Fast", 20000, Fast20000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Fast", 20000, Fast20000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }
        // -----------------------------------------------------------------------------------------------------------------------------------------------//
        //Update Mix 2000kwh Elområde 1-4
        [Route("m2000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> m2000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Mix", 2000, Mix2000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Mix", 2000, Mix2000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Mix", 2000, Mix2000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Mix", 2000, Mix2000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }

        //Update Mix 5000kwh Elområde 1-4
        [Route("m5000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> m5000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Mix", 5000, Mix5000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Mix", 5000, Mix5000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Mix", 5000, Mix5000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Mix", 5000, Mix5000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }
        //Update Mix 20000kwh Elområde 1-4
        [Route("m20000el14")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> m20000el1_4Async(List<string> list)
        {
            try
            {

                var elområde1 = db.Elområden.Where(i => i.Area == "SE01").ToList();
                bool IsReady = await Scrape.GetHtmlAsync("Mix", 20000, Mix20000Elområde1, elområde1[0].ElområdeId);

                var elområde2 = db.Elområden.Where(i => i.Area == "SE02").ToList();
                bool IsReady2 = await Scrape.GetHtmlAsync("Mix", 20000, Mix20000Elområde2, elområde2[0].ElområdeId);

                var elområde3 = db.Elområden.Where(i => i.Area == "SE03").ToList();
                bool IsReady3 = await Scrape.GetHtmlAsync("Mix", 20000, Mix20000Elområde3, elområde3[0].ElområdeId);

                var elområde4 = db.Elområden.Where(i => i.Area == "SE04").ToList();
                bool IsReady4 = await Scrape.GetHtmlAsync("Mix", 20000, Mix20000Elområde4, elområde4[0].ElområdeId);
                return Ok();
            }
            catch (Exception exc)
            {

                return BadRequest();
            }

        }
    }
}
