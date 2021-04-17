using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

        [HttpPost]
        public ActionResult<Client> Post(Client client)
        {

            return client;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            var clientes = new List<Client>() { new Client() { Id = 1, Nome = "Joao" } };
            if (!clientes.Any())
                return NotFound();

            return clientes;
        }








        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        //[ProducesResponseType(404)]
        //public IActionResult Get()
        //{
        //    var clientes = new List<Client>() { new Client() { Id = 1, Nome = "Joao" } };
        //    if (!clientes.Any())
        //        return NotFound();

        //    return Ok( clientes);
        //}

        //[HttpGet]
        //public IEnumerable<Client> Get()
        //{
        //    var clientes = new List<Client>();
        //    //if (!clientes.Any())
        //    //    return NotFound();

        //    return new List<Client>() { new Client() { Id = 1, Nome = "Joao" } };
        //}
    }
}
