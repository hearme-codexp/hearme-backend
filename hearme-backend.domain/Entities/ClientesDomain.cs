using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class ClientesDomain : BaseDomain
    {
        [Required]
        [StringLength(100)]
        string Nome {get; set;}

        [Required]
        [StringLength(20)]
        GeneroDomain Genero {get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        DateTime DataNascimento {get; set;}

        [Required]
        [StringLength(20)]
        GrauDeficienciaDomain GrauDeficiencia {get; set;}
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
        
        public int UsuarioId { get; set; }
    }
}