using Clean.Application;
using Clean.Domain;
using Clean.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Tests
{
    public class TestBase : IDisposable
    {
        protected IMediator _mediator;
        protected IServiceProvider _serviceProvider;

        public TestBase()
        {
            var services = new ServiceCollection();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
            });

            services.AddDbContext<ContasDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            _serviceProvider = services.BuildServiceProvider();

            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        public void Dispose()
        {
            // Limpeza após a execução de todos os testes
        }
    }
}
