

using ConsoleApp6.AppSemaphoreSlim;
using ConsoleApp6.AppTransactionScope;

var semaphoroSlim = new AppSemaphoreSlim();
var transactionScopeAsync = new AppTransactionScopeAsync();
var transactionScopeSync = new AppTransactionScopeSync();

var retorno = false;

do
{
    Console.Clear();
    Console.WriteLine("Fala dev..");
    Console.WriteLine("Qual aplicação deseja iniciar?");
    Console.WriteLine(@"
1 - SemaphoroSlim
2 - TransactionScope em Async
3 - TransactionScope em Sync
    ");


    var valorDigitado = "1"; //Console.ReadLine();
    int.TryParse(valorDigitado, out int numeroApp);

    Console.Clear();

    var retornoApp = numeroApp switch
    {
        1 => await semaphoroSlim.IniciarApp(),
        2 => await transactionScopeAsync.IniciarAppAsync(),
        3 => transactionScopeSync.IniciarAppSync(),
        _ => false
    };

    retorno = retornoApp;
}
while (!retorno);
