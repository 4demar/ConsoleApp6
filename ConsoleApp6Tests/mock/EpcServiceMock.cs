using Domain.Interfaces.Repositorio;
using Domain.Models;
using Moq;
using Service;

namespace ProjetoBaseApi.Tests.Service.mock
{
    public class EpcServiceMock
    {
        public Mock<IEpcRepositorio> EpcRepositoryMock { get; private set; }
        public EpcServico EpcService { get; private set; }

        public EpcServiceMock()
        {
            EpcRepositoryMock = new Mock<IEpcRepositorio>();

            // Instancia a classe real com o mock no construtor
            EpcService = new EpcServico(EpcRepositoryMock.Object);
        }

        private static readonly Random Random = new();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
