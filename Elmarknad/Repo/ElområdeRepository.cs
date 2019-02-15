using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Elmarknad.Models;
using Elmarknad.Repo;
using System.Text;
using System.Diagnostics;

namespace Elmarknad.Repo
{
    public class ElområdeRepository
    {
        public DbEl db = new DbEl();

        public void UpdateJsonFromFile()
        {
            try
            {
                FillDbEl();


                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Models/Webscrape/"), "jsonEl.json");
                if (File.Exists(path))
                    {
                    var watch1 = new Stopwatch();
                    watch1.Start();
                    dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(path, Encoding.UTF8));
                    watch1.Stop();
                    System.Diagnostics.Debug.WriteLine("Läsa in fil: " + watch1.Elapsed);

                    var el1 = db.Elområden.Single(i => i.Area == "SE01");
                    var el2 = db.Elområden.Single(i => i.Area == "SE02");
                    var el3 = db.Elområden.Single(i => i.Area == "SE03");
                    var el4 = db.Elområden.Single(i => i.Area == "SE04");

                    var watch2 = new Stopwatch();
                    watch2.Start();

                    var list = new List<Postnummer>();

                    foreach (var obj in json)
                {
                       

                            if (obj.Elomrade == "SE01")
                            {
                                var postnummer = new Postnummer
                                {
                                    Number = obj.Postnummer,
                                    ElområdeId = el1.ElområdeId
                                };
                                list.Add(postnummer);
                                
                                continue;
                            }

                            if (obj.Elomrade == "SE02")
                            {
                                var postnummer = new Postnummer
                                {
                                    Number = obj.Postnummer,
                                    ElområdeId = el2.ElområdeId
                                };
                                list.Add(postnummer);
                               
                                continue;
                            }

                            if (obj.Elomrade == "SE03")
                            {
                                var postnummer = new Postnummer
                                {
                                    Number = obj.Postnummer,
                                    ElområdeId = el3.ElområdeId
                                };
                                list.Add(postnummer);
                                
                                continue;
                        }
                        else
                        {
                            
                            var postnummer = new Postnummer
                            {
                                Number = obj.Postnummer,
                                ElområdeId = el4.ElområdeId
                            };
                            list.Add(postnummer);

                            continue;
                        }

                   
                }
                    watch2.Stop();
                    System.Diagnostics.Debug.WriteLine("Sortera poster: " + watch2.Elapsed);

                    var watch3 = new Stopwatch();
                    watch3.Start();
                    db.Postnummers.AddRange(list);
                    db.SaveChanges();
                    watch3.Stop();
                    System.Diagnostics.Debug.WriteLine("Spara i databasen: " + watch3.Elapsed);

                }
            }
            catch (Exception exc){
                throw new Exception();
            }

        }

        private void FillDbEl()
        {
            var watch = new Stopwatch();
            watch.Start();

            var list = db.Elområden.ToList();
            db.Elområden.RemoveRange(list);
            db.SaveChanges();
            var listPostnummer = db.Postnummers.ToList();
            db.Postnummers.RemoveRange(listPostnummer);
            db.SaveChanges();
            Elområde Elområde1 = new Elområde
            {
                Area = "SE01"
            };
            Elområde Elområde2 = new Elområde
            {
                Area = "SE02"
            };
            Elområde Elområde3 = new Elområde
            {
                Area = "SE03"
            };
            Elområde Elområde4 = new Elområde
            {
                Area = "SE04"
            };
            db.Elområden.Add(Elområde1);
            db.Elområden.Add(Elområde2);
            db.Elområden.Add(Elområde3);
            db.Elområden.Add(Elområde4);
            db.SaveChanges();

            watch.Stop();
            System.Diagnostics.Debug.WriteLine("Ta bort poster: " + watch.Elapsed);

        }
    }
}