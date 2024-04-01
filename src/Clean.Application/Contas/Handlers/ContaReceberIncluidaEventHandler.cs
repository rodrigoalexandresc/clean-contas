using Clean.Application.Contas.Events;
using Clean.Domain;
using Clean.Domain.Contas;
using MediatR;

namespace Clean.Application.Contas.Handlers
{
    public class ContaReceberIncluidaEventHandler : INotificationHandler<ContaReceberIncluidaEvent>
    {
        private readonly IRepository<ContaReceber, Guid> _repository;

        public ContaReceberIncluidaEventHandler(IRepository<ContaReceber, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ContaReceberIncluidaEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
