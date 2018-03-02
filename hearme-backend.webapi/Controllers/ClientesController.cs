using System;
using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private IBaseRepository<ClientesDomain> _clientesRepository;

        public ClientesController(IBaseRepository<ClientesDomain> clientesRepository){
            _clientesRepository = clientesRepository;
    }
        [HttpGet]
        public IActionResult GetAction(){
            return Ok(_clientesRepository.Listar(new string[]{"Genero","GrauDeficiencia","Usuario"}));
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            ClientesDomain result = _clientesRepository.Buscar(id);
            if(result!=null){
                return Ok(result);
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostAction([FromBody]ClientesDomain cliente){
            var valida = _clientesRepository.Inserir(cliente);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteAction([FromBody]ClientesDomain cliente){
            var valida = _clientesRepository.Deletar(cliente);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
        
            }
        }
    }
}