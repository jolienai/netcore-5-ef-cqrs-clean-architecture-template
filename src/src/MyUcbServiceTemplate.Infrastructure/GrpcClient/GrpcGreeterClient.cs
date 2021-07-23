using CleanArchitectureTemplate.Application.Interfaces;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.GrpcClient
{
    public class GrpcGreeterClientSettings
    {
        public string Address { get; set; }
    }

    public class GrpcGreeterClient : IGrpcGreeterClient
    {
        Task<Application.Interfaces.HelloReply> IGrpcGreeterClient.SayHelloAsync(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
