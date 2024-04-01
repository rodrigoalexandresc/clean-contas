namespace Clean.Domain.Contas
{
    public class ContaReceberParcela : Entity<Guid>
    {
        public override Guid Id { get; set; }
        public Guid ContaReceberId { get; set; }
        public virtual ContaReceber ContaReceber { get; set; }
        public int Numero { get; set; }
        public decimal Valor { get; set; }
    }
}
