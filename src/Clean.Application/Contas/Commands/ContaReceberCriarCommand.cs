using MediatR;

namespace Clean.Application.Contas
{
    public sealed record ContaReceberCriarCommand : IRequest<Guid>
    {
        public Guid PessoaId { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int NumeroParcelas { get; set; }
    }
}
