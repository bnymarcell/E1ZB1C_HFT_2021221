using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICompanyLogic cl;
        ICarLogic carl;
        IDriverLogic dl;

        public StatController(ICompanyLogic cl, ICarLogic carl, IDriverLogic dl)
        {
            this.cl = cl;
            this.carl = carl;
            this.dl = dl;
        }


        // GET: /stat/carcount/
        [HttpGet("{id}")]
        public IEnumerable<string> Carcount(int id)
        {
            return cl.CarCount(id);
        }

        // /stat/howmany
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, int>> HowMany(int id)
        {
            return cl.HowMany(id);
        }

        // GET: /stat/idavg
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> IDAVG()
        {
            return cl.IDAVG();
        }

        // GET: /stat/driveswhat
        [HttpGet("{id}")]
        public IEnumerable<string> DrivesWhat(int id)
        {
            return dl.DrivesWhat(id);
        }

        // GET: /stat/whodrives
        [HttpGet("{id}")]
        public IEnumerable<string> WhoDrives(int id)
        {
            return carl.WhoDrives(id);
        }


        // GET: /stat/driversalary
        [HttpGet("{id}")]
        public IEnumerable<int> DriverSalary(int id)
        {
            return carl.DriverSalary(id);
        }
    }
}
