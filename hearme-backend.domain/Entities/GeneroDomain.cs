using System;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class GeneroDomain : BaseDomain
    {
        [Required]
        [StringLength(20)]
        string Nome {get; set;}
    }
}