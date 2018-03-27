using System;

namespace hearme_backend.webapi.ViewModels
{
    public class HistoricoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime Data { get; set; }
    }
}