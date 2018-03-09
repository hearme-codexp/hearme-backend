using System;
using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using hearme_backend.repository;
using hearme_backend.webapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]")]
    public class CadastrarController : Controller
    {
        private readonly HearMeContext db;

        public CadastrarController(HearMeContext db)
        {
            this.db = db;
        }

        [Route("App")]
        [HttpPost]
        public IActionResult PostActionMobile([FromBody]CadastroApp cadastro)
        {
            var usuario = new UsuarioDomain
            {
                Email = cadastro.Email,
                Senha = cadastro.Senha
            };
            var cliente = new ClientesDomain
            {
                Nome = cadastro.Nome,
                Usuario = usuario,
                DataCriacao = DateTime.Now
            };
            db.Usuarios.Add(usuario);
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return Ok();
        }

        [Route("Web")]
        [HttpPost]
        public IActionResult PostActionWeb([FromBody]CadastroWeb cadastro)
        {
            var usuario = new UsuarioDomain
            {
                Email = cadastro.Email,
                Senha = cadastro.Senha
            };
            var cliente = new ClientesDomain
            {
                Nome = cadastro.Nome,
                Usuario = usuario,
                DataCriacao = DateTime.Now,
                DataNascimento = cadastro.DataDeNascimento,
                Genero = cadastro.Genero,
                GrauDeficiencia = cadastro.GrauDeDeficiencia
            };
            db.Usuarios.Add(usuario);
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return Ok();
        }
    }
}