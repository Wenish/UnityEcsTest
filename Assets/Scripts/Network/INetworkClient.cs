using Colyseus;
using System.Threading.Tasks;

namespace UnityEcsTest.Assets.Scripts.Network
{
    public interface INetworkClient
    {
        Task Connect();

        bool IsConnectedToServer { get; }
    }
}