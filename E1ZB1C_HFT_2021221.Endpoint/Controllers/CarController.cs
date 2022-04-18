using E1ZB1C_HFT_2021221.Endpoint.Services;
using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E1ZB1C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic cl;
        private readonly IHubContext<SignalRHub> hub;

        public CarController(ICarLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }


        // GET: /company
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.ReadAll();
        }

        // GET /Company/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return cl.Read(id);
        }

        // POST /company
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            cl.Create(value);
            hub.Clients.All.SendAsync("CarCreated", value);
        }

        // PUT /company
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            cl.Update(value);
            hub.Clients.All.SendAsync("CarUpdated", value);

        }

        // DELETE /company/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carToDelete = this.cl.Read(id);
            cl.Delete(id);
            hub.Clients.All.SendAsync("CarDeleted", carToDelete);

        }
    }
}
