using hearme_backend.domain.Contracts;
using hearme_backend.domain.Entities;

namespace hearme_backend.domain.TO
{
    public class CadastroTO
    {
        private IBaseRepository<ClientesDomain> _clientesrepository;
        private IBaseRepository<UsuarioDomain> _usuariosrepository;
        public CadastroTO(IBaseRepository<ClientesDomain> clienterepository, IBaseRepository<UsuarioDomain> usuariorepository){
            _clientesrepository = clienterepository;
            _usuariosrepository = usuariorepository;
        }

        public int Cadastrar(ClientesDomain clientes, UsuarioDomain usuario){
            _clientesrepository.Inserir(clientes);
            _usuariosrepository.Inserir(usuario);
            return 0;
        }
    }
}