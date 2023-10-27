using System.Net;
using System.Net.Sockets;

namespace CarStore.Core.Helpers;

public static class NetworkHelper
{
    public static int RandomPort() => new Random(Guid.NewGuid().GetHashCode()).Next(16000, 17000);

    public static string LocalIpAddress() =>
        Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
}