
using System.Transactions;

namespace Servico
{
    public class TransactionScopeService
    {
        public async Task<bool> IniciarAppAsync()
        {
            try
            {
                using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                await PrimeiroComandoAsync();
                await SegundoComandoAsync();

                //var connectionString = "YourConnectionStringHere";
                //using (var connection = new SqlConnection(connectionString))
                //{
                //    await connection.OpenAsync();

                //    // Operação 1
                //    var command1 = new SqlCommand("INSERT INTO Table1 (Column1) VALUES ('Value1')", connection);
                //    await command1.ExecuteNonQueryAsync();

                //    // Operação 2
                //    var command2 = new SqlCommand("INSERT INTO Table2 (Column1) VALUES ('Value2')", connection);
                //    await command2.ExecuteNonQueryAsync();
                //}

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

                PrimeiroComandoSync();
                SegundoComandoSync();

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

        #region Metodos Privados

        private static void PrimeiroComandoSync()
        {
            Task.Delay(3000);
        }

        private static void SegundoComandoSync()
        {
            Task.Delay(3000);
        }

        private static async Task PrimeiroComandoAsync()
        {
            await Task.Delay(3000);
        }

        private static async Task SegundoComandoAsync()
        {
            await Task.Delay(3000);
        }

        #endregion Metodos Privados
    }
}
