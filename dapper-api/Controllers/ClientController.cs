﻿using dapper_api.Entities;
using dapper_api.Services.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dapper_api.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/<ClientController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery(id)));
        }

        // POST api/<ClientController>
        [HttpPost]
        public void CreateClient([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void UpdateClientById(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void DeleteClientById(int id)
        {
        }
    }
}