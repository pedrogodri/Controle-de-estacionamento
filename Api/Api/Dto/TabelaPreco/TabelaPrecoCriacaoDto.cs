namespace Api.Dto.TabelaPreco
{
    public class TabelaPrecoCriacaoDto
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorHoraInicial { get; set; }
        public decimal ValorHoraAdicional { get; set; }
    }
}
