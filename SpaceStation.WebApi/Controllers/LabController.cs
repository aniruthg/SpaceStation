using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceStation.DataAccess.Interfaces;
using SpaceStation.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceStation.WebApi.Controllers
{
    
    public class LabController : Controller
    {
        private readonly ILabSpecification _labSpecification;

        public LabController(ILabSpecification labSpecification)
        {
            _labSpecification = labSpecification;
        }

        // GET: api/<controller>
        [Route("api/[controller]/Get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_labSpecification.GetLabs());
        }

        // GET api/<controller>/5
        [Route("api/[controller]/CheckStatus")]
        [HttpGet]
        public IActionResult CheckStatus([FromQuery]string labId)
        {
            return Ok(_labSpecification.GetLab(labId));
        }

        // POST api/<controller>
        [Route("api/[controller]/Add")]
        [HttpPost]
        public IActionResult Add([FromBody]Lab lab)
        {
            var isValid = _labSpecification.CheckSpecifications(lab);
            if (isValid)
            {
                var result = _labSpecification.AddLab(lab).Result;
                return (result) ? Ok() : StatusCode((int)HttpStatusCode.BadRequest);
            }

            return StatusCode((int)HttpStatusCode.BadRequest);
        }

        [Route("api/[controller]/UpdateStatus")]
        [HttpPost]
        public IActionResult UpdateStatus([FromBody]Lab lab)
        {
           var result = _labSpecification.ChangeLabStatus(lab).Result;
           return (result) ? Ok() : StatusCode((int)HttpStatusCode.BadRequest);
        }

    }
}
