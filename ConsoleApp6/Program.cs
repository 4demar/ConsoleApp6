using Domain.Interfaces.Service;
using Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servico;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ServicoDeConfiguracao.Registrar)
    .Build();

var serviceProvider = host.Services;

await Executar(serviceProvider);

static async Task Executar(IServiceProvider serviceProvider)
{
    var semaphoroSlimService = serviceProvider.GetRequiredService<SemaphoreSlimService>();
    var paginacaoServico = serviceProvider.GetRequiredService<IProdutoServico>();
    var transactionScopeService = serviceProvider.GetRequiredService<TransactionScopeService>();

    bool retorno;

    do
    {
        Console.Clear();
        Console.WriteLine("Fala dev..");
        Console.WriteLine("Qual aplicação deseja iniciar?");
        Console.WriteLine(@"
            1 - SemaphoroSlim
            2 - TransactionScope em Async
            3 - TransactionScope em Sync
            4 - Montar Paginação Produto
            5 - Montar Relatório Base
        ");

        var valorDigitado = "6"; // Console.ReadLine()
        int.TryParse(valorDigitado, out int numeroApp);

        Console.Clear();

        var retornoApp = numeroApp switch
        {
            1 => await semaphoroSlimService.IniciarApp(),
            2 => await transactionScopeService.IniciarAppAsync(),
            3 => transactionScopeService.IniciarAppSync(),
            4 => paginacaoServico.BuscarPaginacaoProduto(),
            5 => paginacaoServico.BuscarPaginacaoProduto(),
            _ => false
        };

        retorno = retornoApp;
    }
    while (!retorno);
}