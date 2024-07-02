using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7000");
            var client = new Greeter.GreeterClient(channel);

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1 - Say hello");
                Console.WriteLine("2 - Say goodbye");
                Console.WriteLine("3 - EXIT");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var reply = await client.SayHelloAsync(
                                          new HelloRequest { Name = "User" });
                        Console.WriteLine("Greeting: " + reply.Message + "\n");
                        break;

                    case "2":
                         var reply2 = await client.SayGoodByeAsync(
                                          new GoodByeRequest { Name = "User" });
                        Console.WriteLine("Farewell: " + reply2.Message + "\n");
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}



/*
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
*/