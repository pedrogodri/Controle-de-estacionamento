namespace Api.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public TimeSpan? Duracao { get; set; }
        public decimal? TempoCobrado { get; set; } // Em horas
        public decimal? PrecoHora { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
