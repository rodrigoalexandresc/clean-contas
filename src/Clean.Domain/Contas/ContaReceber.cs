namespace Clean.Domain.Contas
{
    public class ContaReceber : Entity<Guid>
    {
        public override Guid Id { get; set; }
        public Guid PessoaId { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int NumeroParcelas { get; set; }
        public ContaReceberSituacaoEnum Situacao { get; set; } = ContaReceberSituacaoEnum.Nova;
        public virtual ICollection<ContaReceberParcela>? Parcelas { get; set; }

        public void RecriarParcelas()
        {
            Parcelas = new List<ContaReceberParcela>();
            for (int i = 0; i < NumeroParcelas; i++)
            {
                Parcelas.Add(new ContaReceberParcela
                {
                    ContaReceberId = Id,
                    Numero = i + 1,
                    Valor = Math.Round(this.Valor / NumeroParcelas, 2)
                });
            }
        }

        public void Processar()
        {
            RecriarParcelas();
            Situacao = ContaReceberSituacaoEnum.Processada;
        }
    }
}
