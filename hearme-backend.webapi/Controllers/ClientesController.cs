using System;
using System.Linq;
using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using hearme_backend.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.webapi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/")]
    public class ClientesController : Controller
    {
        private HearMeContext _clientesContext;

        public ClientesController(HearMeContext context)
        {
            _clientesContext = context;
        }
        
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_clientesContext.Clientes
                .Include(c => c.Usuario)
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var cliente = _clientesContext.Clientes.First(e => e.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        
        [HttpPost]
        public IActionResult PostAction([FromBody]ClientesDomain cliente)
        {
            _clientesContext.Clientes.Add(cliente);
            _clientesContext.SaveChanges();
            return Ok(cliente);
        }

        [HttpDelete]
        public IActionResult DeleteAction([FromBody]ClientesDomain cliente)
        {
            _clientesContext.Clientes.Remove(cliente);
            _clientesContext.SaveChanges();
            return Ok(cliente);
        }
    }
}