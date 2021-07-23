using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Interfaces
{
    public class HelloReply
    {
        public string Message { get; set; }
    }

    public interface IGrpcGreeterClient
    {
        Task<HelloReply> SayHelloAsync(string name);
    }
}
