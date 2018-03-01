using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class UsuarioDomain : BaseDomain
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Senha { get; set; }

        public ICollection<UsuarioPermissaoDomain> UsuariosPermissoes { get; set; }
    }
}