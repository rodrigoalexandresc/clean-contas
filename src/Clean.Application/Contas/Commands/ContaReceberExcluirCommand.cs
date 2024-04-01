namespace Clean.Application.Contas
{
    public sealed record ContaReceberExcluirCommand
    {
        public Guid ContaReceberId { get; set; }
    }
}
