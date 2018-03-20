using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using hearme_backend.repository;
using hearme_backend.webapi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace hearme_backend.webapi.Controllers
{

    [Authorize]
    [Route("api/[controller]/")]
    public class UsuarioController : Controller
    {
        private HearMeContext _usuarioContext;

        IConfiguration _configuration;
        public UsuarioController(HearMeContext context, IConfiguration configuration)
        {
            _usuarioContext = context;
            this._configuration = configuration;
        }
/// <summary>
/// Deve ser utilizado para realizar o Login do usuário.
/// </summary>
/// <param name="request"></param>
/// <returns></returns>
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginViewModel), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult RequestToken([FromBody] LoginViewModel request)
        {
            var cliente = _usuarioContext.Clientes.Include(c => c.Usuario).Where(c => c.Usuario.Email == request.Email && c.Usuario.Senha == request.Senha).FirstOrDefault();
            if (cliente!=null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,cliente.Nome)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Usuário ou senha inválidos.");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_usuarioContext.Usuarios
                .ToList());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
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
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public IActionResult PostAction([FromBody]UsuarioDomain usuario)
        {
            _usuarioContext.Usuarios.Add(usuario);
            _usuarioContext.SaveChanges();
            return Ok(usuario);
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        public IActionResult DeleteAction([FromBody]UsuarioDomain usuario)
        {
            _usuarioContext.Usuarios.Remove(usuario);
            _usuarioContext.SaveChanges();
            return Ok(usuario);
        }
    }
}