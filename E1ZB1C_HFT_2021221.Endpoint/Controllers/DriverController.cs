using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E1ZB1C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        IDriverLogic dl;

        public DriverController(IDriverLogic dl)
        {
            this.dl = dl;
        }


        // GET: /company
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return dl.ReadAll();
        }

        // GET /Company/5
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return dl.Read(id);
        }

        // POST /company
        [HttpPost]
        public void Post([FromBody] Driver value)
        {
            dl.Create(value);
        }

        // PUT /company
        [HttpPut]
        public void Put([FromBody] Driver value)
        {
            dl.Update(value);
        }

        // DELETE /company/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
    }
}
