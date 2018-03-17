using hearme_backend.domain.DataTypes;

namespace hearme_backend.webapi.ViewModels
{
    public class AlertaViewModel
    {
        public int IdAlerta { get; set; }
        public string NomeAlerta { get; set; }
        public TipoAlertas TipoAlerta { get; set; }
    }
}