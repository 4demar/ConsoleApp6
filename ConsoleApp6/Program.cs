

using ConsoleApp6.AppSemaphoreSlim;

var semaphoroSlim = new AppSemaphoreSlim();


var retorno = false;

do
{
    Console.Clear();
    Console.WriteLine("Fala dev..");
    Console.WriteLine("Qual aplicação deseja iniciar?");
    Console.WriteLine(@"
1 - SemaphoroSlim
    ");


    var valorDigitado = "1"; //Console.ReadLine();
    int.TryParse(valorDigitado, out int numeroApp);

    Console.Clear();

    var retornoApp = numeroApp switch
    {
        1 => await semaphoroSlim.IniciarApp(),
        2 => false,

        _ => false
    };

    retorno = retornoApp;
}
while (!retorno);
