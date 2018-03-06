using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class HistoricoAlertasDomain : BaseDomain
    {
              
        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("AlertaId")]
        public AlertaDomain Alerta { get; set; }
        public int AlertaId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataHorarioAlerta { get; set; }

        [Required]
        [StringLength(100)]
        public string Localizacao {get; set;}
    }
}