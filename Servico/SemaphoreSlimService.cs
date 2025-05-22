
namespace Servico
{
    public class SemaphoreSlimService
    {
        private readonly SemaphoreSlim semaphore = new(2);
        public async Task<bool> IniciarApp()
        {
            // Libera 2 thread por execução

            // Simula tarefas tentando acessar o recurso
            Task[] tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                int taskNumber = i + 1; // Apenas para identificação
                tasks[i] = Task.Run(async () =>
                {
                    Console.WriteLine($"Task {taskNumber} esperando para acessar o recurso.");
                    await semaphore.WaitAsync(); // Aguarda disponibilidade
                    try
                    {
                        Console.WriteLine($"Task {taskNumber} executando o recurso.");
                        await Task.Delay(3000); // Simula trabalho
                    }
                    finally
                    {
                        Console.WriteLine($"Task {taskNumber} liberou o acesso ao recurso.");
                        semaphore.Release(); // Libera o recurso
                    }
                });

                // Ou aplique o semaphore no metodo 
                // await ExecutarRecurso(taskNumber)
            }

            // Aguarda todas as tarefas concluírem
            // Caso houver lista de tarefas...
            await Task.WhenAll(tasks);

            Console.WriteLine("Todas as tarefas concluídas.");

            return true;
        }

        public async Task ExecutarRecurso(int taskNumber)
        {
            Console.WriteLine($"Task {taskNumber} esperando para acessar o recurso.");

            // só executa se houver disponibilidade
            await semaphore.WaitAsync(); // Aguarda disponibilidade
            try
            {
                Console.WriteLine($"Task {taskNumber} acessou o recurso.");
                await Task.Delay(5000); // Simula Executando trabalho
            }
            finally
            {
                Console.WriteLine($"Task {taskNumber} liberou o recurso.");
                semaphore.Release(); // Libera o recurso
            }
        }
    }
}

//Exemplo de Execução
//    Task 1 esperando para acessar o recurso.
//    Task 1 executando o recurso.
//    Task 3 esperando para acessar o recurso.
//    Task 3 executando o recurso.
//    Task 2 esperando para acessar o recurso.
//    Task 4 esperando para acessar o recurso.
//    Task 5 esperando para acessar o recurso.
//    Task 3 liberou o acesso ao recurso.
//    Task 1 liberou o acesso ao recurso.
//    Task 2 executando o recurso.
//    Task 4 executando o recurso.
//    Task 4 liberou o acesso ao recurso.
//    Task 2 liberou o acesso ao recurso.
//    Task 5 executando o recurso.
//    Task 5 liberou o acesso ao recurso.