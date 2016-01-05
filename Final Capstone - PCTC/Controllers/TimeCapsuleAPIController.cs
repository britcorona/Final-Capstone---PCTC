using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Capstone___PCTC.Controllers
{
    public class TimeCapsuleAPIController : ApiController
    {
        public string Get()
        {
            return "Is this working?";
        }
        // GET: api/TimeCapsuleAPI
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/TimeCapsuleAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TimeCapsuleAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TimeCapsuleAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TimeCapsuleAPI/5
        public void Delete(int id)
        {
        }
    }
}
