using System;
using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private IBaseRepository<UsuarioDomain> _usuarioRepository;

        public UsuarioController(IBaseRepository<UsuarioDomain> usuarioRepository){
            _usuarioRepository = usuarioRepository;
    }
        [HttpGet]
        public IActionResult GetAction(){
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            UsuarioDomain result = _usuarioRepository.Buscar(id);
            if(result!=null){
                return Ok(result);
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostAction([FromBody]UsuarioDomain usuario){
            var valida = _usuarioRepository.Inserir(usuario);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteAction([FromBody]UsuarioDomain usuario){
            var valida = _usuarioRepository.Deletar(usuario);
            if(valida>0){
                return Ok();
            }else{
                return NotFound();
        
            }
        }
    }
}