namespace Clean.Application.Contas
{
    public sealed record ContaReceberAlterarCommand
    {
        public Guid ContaReceberId { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
