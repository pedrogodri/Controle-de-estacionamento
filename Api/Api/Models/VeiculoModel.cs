namespace Api.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }    
    }
}
