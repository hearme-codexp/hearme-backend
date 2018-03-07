using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class ClientesDomain : BaseDomain
    {
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}


        [DataType(DataType.DateTime)]
        DateTime DataNascimento {get; set;}
      
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("GeneroId")]
        public GeneroDomain Generos  { get; set; }
        public int GeneroId { get; set; }

        [ForeignKey("GrauDeficienciaId")]
        public GrauDeficienciaDomain GrausDeficiencia { get; set; }
        public int GrauDeficienciaId { get; set; }

        public ICollection<HistoricoAlertasDomain> HistoricosAlertasDomain { get; set; }
    }
}