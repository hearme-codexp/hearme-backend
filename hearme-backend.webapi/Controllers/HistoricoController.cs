using System;
using System.Collections.Generic;
using System.Globalization;
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
            var cliente = _historicoContext.Clientes.FirstOrDefault(e => e.Id == id);
            if(cliente == null)
                return BadRequest("Usuário Inválido");
            var histcompleto = _historicoContext.Historico.Where(e => e.ClienteId == id)
                .Include(c => c.Alerta)
                .Select(h => new HistoricoViewModel(){
                    Id = h.Id,
                    Nome = h.Alerta.Nome,
                    Longitude = h.Lon,
                    Latitude = h.Lat,
                    Data = h.DataHorarioAlerta
                });
            if(histcompleto == null)
                return BadRequest("Usuario inválido");
            

            return Ok(histcompleto);
        }
        
        /// <summary>
        /// Lista a quantidade de Alertas por Minuto conforme o Id do Cliente.
        /// </summary>
        /// <remarks>
        ///  
        /// </remarks>
        /// <param name="id">Informar o Id do Cliente</param>
        /// <returns></returns>
        [HttpGet("cliente/Graph/{id}")]
        [ProducesResponseType(typeof(IEnumerable<HistoricoGraph>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult GetActionGraph(int id)
        {
            var cliente = _historicoContext.Clientes.Any(e => e.Id == id);
            if(!cliente)
                return BadRequest("Usuário Inválido");
            DateTime today = DateTime.Now;
            DateTime fiveDaysAgo = today.AddDays(-60);
            var histcompleto = _historicoContext.Historico
                .Where(
                    e => e.ClienteId == id
                    && 
                    e.DataHorarioAlerta >= fiveDaysAgo
                )
                .Include(c => c.Alerta)
                .GroupBy(i => i.DataHorarioAlerta.ToString("dd/MM/yyyy HH:mm"))
                .Select(i => new{
                    Hora = DateTime.ParseExact(i.Key, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    Count = i.Count()
                });
            return Ok(histcompleto);
        }

        /// <summary>
        /// Deve ser utilizado para cadastar o histórico de alertas do cliente.
        /// </summary>
        /// <param name="historico"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<HistoricoPostViewModel>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult PostAction([FromBody]HistoricoPostViewModel historico)
        {
            var cliente = _historicoContext.Clientes.FirstOrDefault(e => e.Id == historico.ClienteId);
            if(cliente == null)
                return BadRequest("Usuário Inválido");
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
            return Ok();
        }

    }
}