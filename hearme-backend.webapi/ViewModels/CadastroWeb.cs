using System;
using hearme_backend.domain.DataTypes;

namespace hearme_backend.webapi.ViewModels
{
    public class CadastroWeb
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Genero Genero { get; set; }
        public GrauDeficiencia GrauDeDeficiencia { get; set; }
    }
}