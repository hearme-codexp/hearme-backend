using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class HistoricoAlertasDomain : Base
    {
              
        [ForeignKey("ClienteId")]
        public ClientesDomain Cliente { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("AlertaId")]
        public Alerta Alerta { get; set; }
        public int AlertaId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataHorarioAlerta { get; set; }

        [Required]
        [StringLength(100)]
        public string Localizacao {get; set;}
    }
}