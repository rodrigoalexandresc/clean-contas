using Clean.Application.Contas;
using Clean.Domain;
using Clean.Domain.Contas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Tests
{
    [Collection("TesteGlobal")]
    public class ContaReceberCriarCmdHandlerTests : TestBase
    {
        [Fact]
        public async Task ContaReceberCriar_Deve_Criar_Registro()
        {
            var repo = _serviceProvider.GetRequiredService<IReadOnlyRepository<ContaReceber, Guid>>();

            var id = await _mediator.Send(new ContaReceberCriarCommand());
            Assert.NotEqual(Guid.Empty, id);

            var conta = await repo.GetAsync(id);
            Assert.NotNull(conta);
        }

        [Fact]
        public async Task ContaReceber_Criada_Deve_Incluir_Todas_Parcelas()
        {
            var repo = _serviceProvider.GetRequiredService<IReadOnlyRepository<ContaReceber, Guid>>();

            var id = await _mediator.Send(new ContaReceberCriarCommand
            {
                Descricao = "Boleto Feliz",
                Valor = 1000,
                NumeroParcelas = 4
            });

            var conta = await repo.Query().Include(i => i.Parcelas).FirstOrDefaultAsync(o => o.Id == id);

            Assert.NotEqual(Guid.Empty, id);
            Assert.NotNull(conta);
            Assert.Equal(4, conta.Parcelas.Count());
            Assert.Equal(250, conta.Parcelas.FirstOrDefault().Valor);
        }
    }
}