using E1ZB1C_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]")]
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
        
    }
}
