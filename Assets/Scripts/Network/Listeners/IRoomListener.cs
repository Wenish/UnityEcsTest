using Colyseus;

namespace UnityEcsTest.Assets.Scripts.Network.Listeners
{
    public interface IRoomListener
    {
        void OnChange(DataChange obj);
    }
}