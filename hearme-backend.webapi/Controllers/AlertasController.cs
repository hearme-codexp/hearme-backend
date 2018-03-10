using System.Linq;
using hearme_backend.repository;
using Microsoft.AspNetCore.Mvc;
using hearme_backend.domain.Entities;

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

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_alertasContext.Alertas.ToList());
        }

        [HttpPost]
        public IActionResult PostAction([FromBody]Alerta alerta)
        {
            _alertasContext.Alertas.Add(alerta);
            _alertasContext.SaveChanges();
            return Ok(alerta);
        }
    }
}