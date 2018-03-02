using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class GeneroDomain : BaseDomain
    {
        [Required]
        [StringLength(20)]
        string Nome {get; set;}

        public ICollection<ClientesDomain> Clientes { get; set; }
    }
}