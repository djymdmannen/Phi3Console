using System.Text;

internal class Program
{
    private static async Task Main(string[] _)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

       await ChatApplication.StartAsync("phi3");
    }
}