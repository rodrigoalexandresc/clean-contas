namespace Clean.Domain
{
    public abstract class Entity<Identifier>
    {
        public abstract Identifier Id { get; set; }
    }
}
