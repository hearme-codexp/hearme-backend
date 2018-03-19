using System.Collections.Generic;
using System.Linq;
using hearme_backend.domain.Entities;
using hearme_backend.repository;
using hearme_backend.webapi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.webapi.Controllers
{
    [Route("api/[controller]/")]
    public class HistoricoController : Controller
    {
        private HearMeContext _historicoContext;

        public HistoricoController(HearMeContext context)
        {
            _historicoContext = context;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_historicoContext.Historico
                .Include(c => c.Alerta)
                .Include(c => c.Cliente)
                .ToList());
        }

        /// <summary>
        /// Lista o Histórico de Alertas conforme o Id do Cliente.
        /// </summary>
        /// <remarks>
        ///  
        /// </remarks>
        /// <param name="id">Informar o Id do Cliente</param>
        /// <returns></returns>
        [HttpGet("cliente/{id}")]
        [ProducesResponseType(typeof(IEnumerable<HistoricoViewModel>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult GetAction(int id)
        {
            var histcompleto = _historicoContext.Historico.Where(e => e.ClienteId == id)
                .Include(c => c.Alerta)
                .Select(h => new HistoricoViewModel(){
                    IdHistoricoAlerta = h.Id,
                    NomeAlerta = h.Alerta.Nome,
                    Longitude = h.Lon,
                    Latitude = h.Lat,
                    DataHistoricoAlerta = h.DataHorarioAlerta
                });

             

            return Ok(histcompleto);
        }
/// <summary>
/// Deve ser utilizado para cadastar o histórico de alertas do cliente.
/// </summary>
/// <param name="historico"></param>
/// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult PostAction([FromBody]HistoricoAlertasDomain historico)
        {
            var historicoalertas = new HistoricoAlertasDomain
            {
                ClienteId = historico.ClienteId,
                AlertaId = historico.AlertaId,
                DataHorarioAlerta = historico.DataHorarioAlerta,
                Lat = historico.Lat,
                Lon = historico.Lon
            };
                        
            _historicoContext.Historico.Add(historicoalertas);
            _historicoContext.SaveChanges();
            return Ok(historico);
        }

    }
}