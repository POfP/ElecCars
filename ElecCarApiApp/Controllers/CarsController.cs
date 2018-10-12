using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElecCarApiApp.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DIClass;

namespace ElecCarApiApp.Controllers
{
   
    public class CarsController : ODataController
    {

        private readonly IConfiguration configuration;

        private ElecCarContext _db;
        private IMyDependency _myDependency;

        public CarsController(ElecCarContext context, IMyDependency myDependency,  IConfiguration config)
        {
            configuration = config;
            _myDependency = myDependency;
            _db = context;

            myDependency.WriteMessage("shdfghsdgf");

             if (context.Cars.Count() == 0)
            {
                foreach (var b in DataSource.GetCars())
                {
                    context.Cars.Add(b);
                   // context.Manufacturers.Add(b.Manufacturer);
                }
                context.SaveChanges();
            }
        }

        [Authorize]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Cars);
        }

        [Authorize]
        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Cars.FirstOrDefault(c => c.Id == key));
        }

        [Authorize]
        [EnableQuery]
        public IActionResult Post([FromBody]Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
            return Ok();
        }

        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get_default()
        //{ 
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get_default(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
