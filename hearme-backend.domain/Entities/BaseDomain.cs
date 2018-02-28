using System;
using System.ComponentModel.DataAnnotations;

namespace hearme_backend.domain.Entities
{
    public class BaseDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}