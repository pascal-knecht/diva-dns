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
        public ActionResult<string> GetDomainName([FromRoute] string domainName)
        {
            return Ok(domainName);
        }

        [HttpPut("{domainName}", Name = $"{nameof(PutDomainName)}")]
        [ProducesResponseType(typeof(DomainCreatedDto), 200)]
        public ActionResult<DomainCreatedDto> PutDomainName([FromBody] CreateDomainDto domainName)
        {
            return Ok(new DomainCreatedDto(domainName.DomainName));
        }
    }
}