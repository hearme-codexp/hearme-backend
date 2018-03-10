using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hearme_backend.domain.DataTypes;

namespace hearme_backend.domain.Entities
{
    public class Alerta : Base
    {
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        [Required]
        public TipoAlertas TipoAlertas {get; set;}      

        public ICollection<HistoricoAlertasDomain> HistoricosAlertasDomain { get; set; }
    }
}