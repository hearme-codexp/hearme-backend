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
    public class UsuarioController : Controller
    {
        private HearMeContext _usuarioContext;

        public UsuarioController(HearMeContext context)
        {
            _usuarioContext = context;
        }

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_usuarioContext.Usuarios
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            var usuario = _usuarioContext.Usuarios.First(e => e.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        
        [HttpPost]
        public IActionResult PostAction([FromBody]UsuarioDomain usuario)
        {
            _usuarioContext.Usuarios.Add(usuario);
            _usuarioContext.SaveChanges();
            return Ok(usuario);
        }

        [HttpDelete]
        public IActionResult DeleteAction([FromBody]UsuarioDomain usuario)
        {
            _usuarioContext.Usuarios.Remove(usuario);
            _usuarioContext.SaveChanges();
            return Ok(usuario);
        }
    }
}