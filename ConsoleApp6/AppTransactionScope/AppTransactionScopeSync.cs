using System.Transactions;

namespace ConsoleApp6.AppTransactionScope
{
    public class AppTransactionScopeSync
    {
        public bool IniciarAppSync()
        {
            try
            {
                using var scope = new TransactionScope(TransactionScopeOption.Required,
                                     new TransactionOptions
                                     {
                                         IsolationLevel = IsolationLevel.ReadUncommitted,
                                         Timeout = new TimeSpan(0, 3, 0)
                                     });

                PrimeiroComando();
                SegundoComando();

                // Completa a transação
                scope.Complete();
                Console.WriteLine("Transação concluída com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na transação: {ex.Message}");
                return false;
            }
        }

        private static void PrimeiroComando()
        {
            Task.Delay(3000);
        }

        private static void SegundoComando()
        {
            Task.Delay(3000);
        }
    }
}
