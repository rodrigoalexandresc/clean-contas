using Clean.Application.Contas.Events;
using Clean.Domain;
using Clean.Domain.Contas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Contas
{
    public class ContaReceberCriarCmdHandler : IRequestHandler<ContaReceberCriarCommand, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ContaReceber, Guid> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContaReceberCriarCmdHandler(IRepository<ContaReceber, Guid> repository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ContaReceberCriarCommand request, CancellationToken cancellationToken)
        {
            var entity = new ContaReceber();

            entity.PessoaId = request.PessoaId;
            entity.Descricao = request.Descricao;
            entity.Valor = request.Valor;
            entity.NumeroParcelas = request.NumeroParcelas;            
            entity.Id = Guid.NewGuid();

            entity.Processar();

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            await _mediator.Publish(new ContaReceberIncluidaEvent { ContaReceber = entity });

            return entity.Id;
        }
    }
}
