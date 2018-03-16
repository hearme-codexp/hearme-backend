using System.Linq;
using hearme_backend.repository;
using Microsoft.AspNetCore.Mvc;
using hearme_backend.domain.Entities;
using System.Collections.Generic;

namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]")]
    public class AlertasController : Controller
    {
        private readonly HearMeContext _alertasContext;

        public AlertasController(HearMeContext context)
        {
            _alertasContext = context;
        }
        /// <summary>
        /// Deve ser utilizado para listar os Alertas cadastrados. 
        /// </summary>
        /// <remarks>
        /// Lista os Alertas cadastrados no BD (provindos da tabela Alertas). 
        /// </remarks>
        /// <returns> Caso não apresente erro, apresenta a lista de alertas cadastrados no BD.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Alerta), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult GetAction()
        {
            return Ok(_alertasContext.Alertas.ToList());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        /// <summary>
        /// Deve ser utilizado para o cadastro de novos Alertas. 
        /// </summary>
        /// <remarks>
        /// Realiza o cadastro do Alerta.
        /// Deverá ser cadastrado o Nome do Alerta e o Tipo de Alerta (Reconhecimento ou Volume).
        /// No MVP só será utilizado o Tipo de Alerta Volume.
        /// </remarks>
        /// <returns> Caso não apresente erro, o cadastro do Nome do Alerta e o Tipo de Alerta foram salvos com sucesso.</returns>
        [HttpPost]
        public IActionResult PostAction([FromBody]Alerta alerta)
        {
            _alertasContext.Alertas.Add(alerta);
            _alertasContext.SaveChanges();
            return Ok(alerta);
        }
    }
}