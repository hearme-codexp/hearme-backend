using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace hearme_backend.domain.Entities
{
    public class UsuarioDomain : Base
    {


        [Required]
        [EmailAddress(ErrorMessage = "Por favor insira um e-mail válido.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [StringLength(500)]
        public string Token { get; set; }
    }
}