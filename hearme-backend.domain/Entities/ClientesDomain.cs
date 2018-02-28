
namespace hearme_backend.domain.Entities
{
    public class ClientesDomain
    {
        string Nome {get; set;}
        Genero Genero {get; set;}
        DateTime DataNascimento {get; set;}
        GrauDeficiencia GrauDeficiencia {get; set;}
    }
}