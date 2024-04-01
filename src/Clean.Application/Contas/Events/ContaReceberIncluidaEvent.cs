using Clean.Domain.Contas;
using MediatR;

namespace Clean.Application.Contas.Events
{
    public sealed record ContaReceberIncluidaEvent : INotification
    {
        public ContaReceber ContaReceber { get; set; }
    }
}
