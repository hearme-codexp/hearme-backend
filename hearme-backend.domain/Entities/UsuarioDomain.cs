using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class UsuarioDomain : BaseDomain
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Senha { get; set; }

        [ForeignKey("ClienteId")]
        public UsuarioDomain Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}