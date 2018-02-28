
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
        Genero Genero {get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        DateTime DataNascimento {get; set;}

        [Required]
        [StringLength(20)]
        GrauDeficiencia GrauDeficiencia {get; set;}
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
    }
}