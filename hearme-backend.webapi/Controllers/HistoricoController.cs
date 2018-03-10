using System.Linq;
using hearme_backend.domain.Entities;
using hearme_backend.repository;
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

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_historicoContext.Historico
                .Include(c => c.Alerta)
                .Include(c => c.Cliente)
                .ToList());
        }


        [HttpGet("cliente/{id}")]
        public IActionResult GetAction(int id)
        {
            var historico = _historicoContext.Historico.Where(e => e.ClienteId == id)
                .Include(c => c.Alerta)
                .Include(c => c.Cliente)
                .Select(h => new {
                    idAlerta = h.AlertaId,
                    nomeAlerta = h.Alerta.Nome,
                    idCliente = h.ClienteId,
                    nomeCliente = h.Cliente.Nome,
                    longitude = h.Lon,
                    latitude = h.Lat,
                    dataAlerta = h.DataHorarioAlerta
                });

            return Ok(historico);
        }

        [HttpPost]
        public IActionResult PostAction([FromBody]HistoricoAlertasDomain historico)
        {
            _historicoContext.Historico.Add(historico);
            _historicoContext.SaveChanges();
            return Ok(historico);
        }

    }
}