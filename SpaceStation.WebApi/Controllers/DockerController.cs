using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceStation.DataAccess.Interfaces;
using SpaceStation.Models.Interfaces;
using SpaceStation.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceStation.WebApi.Controllers
{
   [ApiController]
   
    public class DockerController : Controller
    {
        private readonly IShuttleSpecifications _shuttleSpecifications;
        public DockerController(IShuttleSpecifications shuttleSpecifications)
        {
            _shuttleSpecifications = shuttleSpecifications;
        }


        // POST api/<controller>
        [Route("api/[controller]/dock")]
        [HttpPost]
        public IActionResult Dock([FromBody]Shuttle shuttle)
        {
            var isValid = _shuttleSpecifications.CheckSpecifications(shuttle);
            if (isValid)
            {
               var result= _shuttleSpecifications.DockShuttle(shuttle).Result;
                return (result)?Ok(): StatusCode((int)HttpStatusCode.BadRequest);
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }

        [Route("api/[controller]/undock")]
        [HttpPost]
        public IActionResult UnDock([FromQuery]string shuttleId)
        {
            var result =  _shuttleSpecifications.UndockShuttle(shuttleId).Result;
            return (result) ? Ok() : StatusCode((int)HttpStatusCode.BadRequest);
        }


    }
}
