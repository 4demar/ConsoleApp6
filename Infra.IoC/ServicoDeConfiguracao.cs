using Domain.Interfaces.Repositorio;
using Domain.Interfaces.Service;
using Dominio.Interface.Service;
using Infra.Banco.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Servico;

namespace Infra.IoC
{
    public static class ServicoDeConfiguracao
    {
        public static void Registrar(this IServiceCollection services)
        {
            AddServicesProjeto(services);
            AddRepositoriesProjeto(services);
        }

        public static void AddServicesProjeto(this IServiceCollection services)
        {
            services.AddTransient<IEpcServico, EpcServico>();
            services.AddTransient<IProdutoServico, ProdutoServico>();
            services.AddTransient<IPermissaoServico, PermissaoServico>();
            services.AddTransient<IExcelServico, ExcelServico>();
            services.AddTransient<Calculadora>();
            services.AddTransient<SemaphoreSlimService>();
            services.AddTransient<TransactionScopeService>();
        }

        public static void AddRepositoriesProjeto(this IServiceCollection services)
        {
            services.AddTransient<IEpcRepositorio, EpcRepositorio>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddTransient<IPermissaoRepositorio, PermissaoRepositorio>();
        }
    }
}
