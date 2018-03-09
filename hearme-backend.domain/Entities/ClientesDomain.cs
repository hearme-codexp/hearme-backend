using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hearme_backend.domain.DataTypes;

namespace hearme_backend.domain.Entities
{
    public class ClientesDomain : Base
    {
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        [DataType(DataType.DateTime)]
        public DateTime DataNascimento {get; set;}
      
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Genero Genero { get; set; }

        public GrauDeficiencia GrauDeficiencia { get; set; }

        public ICollection<HistoricoAlertasDomain> HistoricosAlertasDomain { get; set; } 
    }
}