using System.Transactions;

namespace ConsoleApp6.AppTransactionScope
{
    public class AppTransactionScopeAsync
    {
        public async Task<bool> IniciarAppAsync()
        {
            try
            {
                using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                await PrimeiroComando();
                await SegundoComando();

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

        private static async Task PrimeiroComando()
        {
            await Task.Delay(3000);
        }

        private static async Task SegundoComando()
        {
            await Task.Delay(3000);
        }
    }
}
