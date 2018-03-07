using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using hearme_backend.domain.Repository;
using hearme_backend.domain.TO;
using Microsoft.AspNetCore.Mvc;

namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]")]
    public class CadastrarController : Controller
    {
        private CadastroTO _cadastroTO;

        public CadastrarController(IBaseRepository<ClientesDomain> clientesRepository, IBaseRepository<UsuarioDomain> usuariosRepository){
            _cadastroTO = new CadastroTO(clientesRepository, usuariosRepository);
        }

        [HttpPost]
        public IActionResult PostAction([FromBody]CadastroViewModel cadastro){
            var cliente = new ClientesDomain
            {  
                Nome = cadastro.Nome
            };
            var usuario = new UsuarioDomain
            {
                Email = cadastro.Email,
                Senha = cadastro.Senha
            };
            int valida  = _cadastroTO.Cadastrar(cliente, usuario);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}