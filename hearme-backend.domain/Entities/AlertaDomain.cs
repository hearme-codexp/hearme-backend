using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class AlertaDomain : BaseDomain
    {
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        [Required]
        [StringLength(100)]
        public string Tipo {get; set;}

        [Required]
        [Range(1,10)]
        public int DuracaoVibracoes{get; set;}        

        public ICollection<HistoricoAlertasDomain> HistoricosAlertasDomain { get; set; }
    }
}