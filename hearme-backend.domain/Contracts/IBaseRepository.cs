using System.Collections.Generic;

namespace hearme_backend.domain.Contracts
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Listar(string[] includes = null);
        int Atualizar(T dados);
        int Inserir(T dados);
        T Buscar(int id, string[] includes = null)

    }
}