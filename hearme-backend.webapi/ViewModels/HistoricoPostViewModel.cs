using System;

namespace hearme_backend.webapi.ViewModels
{
    public class HistoricoPostViewModel
    {
        public int ClienteId { get; set; }
        public int AlertaId { get; set; }
        public DateTime DataHorarioAlerta { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}