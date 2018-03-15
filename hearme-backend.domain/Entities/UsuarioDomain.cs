using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hearme_backend.domain.Entities
{
    public class UsuarioDomain : Base
    {
        

        [Required]
        [EmailAddress(ErrorMessage = "Por favor insira um e-mail válido.")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)] 
        public string Senha { get; set; }

        [StringLength(100)]
        public string Token { get; set; }
    }
}