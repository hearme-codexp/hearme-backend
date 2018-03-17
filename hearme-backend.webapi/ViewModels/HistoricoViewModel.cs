using System;

namespace hearme_backend.webapi.ViewModels
{
    public class HistoricoViewModel
    {
        public int IdHistoricoAlerta { get; set; }
        public string NomeAlerta { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime DataHistoricoAlerta { get; set; }
    }
}