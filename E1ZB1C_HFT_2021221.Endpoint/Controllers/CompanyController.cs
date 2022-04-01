using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E1ZB1C_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E1ZB1C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyLogic cl;
        private readonly IHubContext<SignalRHub> hub;

        public CompanyController(ICompanyLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }


        // GET: /company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return cl.ReadAll();
        }

        // GET /Company/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return cl.Read(id);
        }

        // POST /company
        [HttpPost]
        public void Post([FromBody] Company value)
        {
            cl.Create(value);
            hub.Clients.All.SendAsync("CompanyCreated", value);
        }

        // PUT /company
        [HttpPut]
        public void Put([FromBody] Company value)
        {
            cl.Update(value);
            hub.Clients.All.SendAsync("CompanyUpdated", value);

        }

        // DELETE /company/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.cl.Read(id);
            cl.Delete(id);
            hub.Clients.All.SendAsync("CompanyDeleted", actorToDelete);

        }
    }
}
