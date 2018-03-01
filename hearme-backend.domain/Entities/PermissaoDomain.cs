using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class PermissaoDomain : BaseDomain
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public ICollection<UsuarioPermissaoDomain> UsuariosPermissoes { get; set; }
    }
}