using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

try
{
    var ipEndPoint = ReadIPEndPointFromConfig();
    int pingCounter = 0;
    string message;

    while (true)
    {
        message = $"ping counter: {pingCounter++}";

        using (TcpClient client = new TcpClient())
        {
            client.Connect(ipEndPoint);

            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = Encoding.ASCII.GetBytes(message);

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                int bytesRead = stream.Read(data, 0, data.Length);
                
                Console.WriteLine("Received: {0}", 
                    Encoding.ASCII.GetString(data, 0, bytesRead));
            }
        }

        Thread.Sleep(3678);
    }
}
catch (ArgumentNullException e)
{
    Console.WriteLine("ArgumentNullException: {0}", e);
}
catch (SocketException e)
{
    Console.WriteLine("SocketException: {0}", e);
}

IPEndPoint ReadIPEndPointFromConfig()
{
    const string HOST_CONFIGURATION_KEY = "TcpDestination:Host";
    const string PORT_CONFIGURATION_KEY = "TcpDestination:Port";

    var ipAddress = IPAddress.Loopback;
    var port = 3092;

    IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    if (IPAddress.TryParse(configuration[HOST_CONFIGURATION_KEY], out IPAddress? parsedIPAddress))
    {
        ipAddress = parsedIPAddress;
    }

    if (int.TryParse(configuration[PORT_CONFIGURATION_KEY], out int parsedPort))
    {
        port = parsedPort;
    }

    return new IPEndPoint(ipAddress, port);
}