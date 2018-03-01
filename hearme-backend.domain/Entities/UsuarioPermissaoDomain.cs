using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class UsuarioPermissaoDomain
    {
        [ForeignKey("UsuarioId")]
        public UsuarioDomain  Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("PermissaoId")]
        public PermissaoDomain Permissao { get; set; }
        public int PermissaoId { get; set; }
    }
}