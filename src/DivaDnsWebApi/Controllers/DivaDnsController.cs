﻿using DivaDnsWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DivaDnsWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DivaDnsController : ControllerBase
    {
        private readonly ILogger<DivaDnsController> _logger;

        public DivaDnsController(ILogger<DivaDnsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{domainName}", Name = $"{nameof(GetDomainName)}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public ActionResult<string> GetDomainName([FromRoute] string domainName)
        {
            return Ok(domainName);
        }

        [HttpPut(Name = $"{nameof(PutDomainName)}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(502)]
        public ActionResult PutDomainName([FromBody] CreateDomainDto createDomainDto)
        {
            return Ok();
        }
    }
}
