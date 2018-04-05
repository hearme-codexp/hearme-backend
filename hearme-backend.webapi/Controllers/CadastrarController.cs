using System;
using System.Linq;
using System.Security.Cryptography;
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

        /// <summary>
        /// Deve ser utilizado para o cadastro de novos usuários via Mobile. 
        /// </summary>
        /// <remarks>
        /// Realiza o cadastro do Usuario contendo Email e Senha.
        /// Após o cadastro do usuário deverá ser realizado o cadastro Clientes 
        /// com a inclusão do Nome. Os dados Usuario e
        /// DataCriacao serão cadastrados automaticamente.
        /// </remarks>
        /// <param name="cadastro"></param>
        /// <returns> Caso não apresente erro, foram adicionados os dados referentes ao Usuario 
        /// e Clientes nas suas respectivas tabelas as alterações foram salvas no BD.</returns>
        [HttpPost]
        [Route("App")]
        [ProducesResponseType(typeof(CadastroApp), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult PostActionMobile([FromBody]CadastroApp cadastro)
        {
            var emailJaExiste = db.Usuarios.Any(e => e.Email == cadastro.Email);
            if(emailJaExiste)
                return BadRequest("Email já cadastrado");
            var u = new CriptografaJa();
            var usuario = new UsuarioDomain
            {
                Email = cadastro.Email,
                Senha = u.generateHashString(cadastro.Senha)
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


        /// <summary>
        /// Deve ser utilizado para o cadastro de novos usuários via Web. 
        /// </summary>
        /// <remarks>
        /// Realiza o cadastro do Usuario contendo Email e Senha.
        ///Após o cadastro do usuário deverá ser realizado o cadastro Clientes 
        ///com a inclusão do Nome, DataNascimento, Genero, GrauDeficiencia. Os dados Usuario e
        ///DataCriacao serão cadastrados automaticamente.
        /// </remarks>
        /// <param name="cadastro"></param>
        /// <returns>Caso não apresente erro, foram adicionados os dados referentes ao Usuario 
        /// e Clientes nas suas respectivas tabelas as alterações foram salvas no BD.</returns>
        [Route("Web")]
        [HttpPost]
        [ProducesResponseType(typeof(CadastroWeb), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult PostActionWeb([FromBody]CadastroWeb cadastro)
        {
            var emailJaExiste = db.Usuarios.Any(e => e.Email == cadastro.Email);
            if(emailJaExiste)
                return BadRequest("Email já cadastrado");

            var u = new CriptografaJa();
            var usuario = new UsuarioDomain
            {
                Email = cadastro.Email,
                Senha = u.generateHashString(cadastro.Senha)
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