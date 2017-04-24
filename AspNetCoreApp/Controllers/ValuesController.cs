using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreApp.ValuesDomain;

namespace AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _valuesService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _valuesService.GetBy(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
