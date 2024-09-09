using System.ComponentModel.DataAnnotations;

namespace Api.Dto.TabelaPreco
{
    public class TabelaPrecoCriacaoDto
    {
        [Required(ErrorMessage = "A Data de Início é obrigatória.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A Data de Fim é obrigatória.")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O Valor da Hora Inicial é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor da Hora Inicial deve ser maior que zero.")]
        public decimal ValorHoraInicial { get; set; }

        [Required(ErrorMessage = "O Valor da Hora Adicional é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor da Hora Adicional deve ser maior que zero.")]
        public decimal ValorHoraAdicional { get; set; }
    }
}
