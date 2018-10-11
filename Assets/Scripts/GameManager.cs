using UnityEcsTest.Assets.Scripts.Network;
using UnityEcsTest.Assets.Scripts.Network.Listeners.Players;
using UnityEngine;

namespace UnityEcsTest.Assets.Scripts
{
    public class GameManager
    {
        private static ColyseusClient _colyseusClient;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Start()
        {
            _colyseusClient = new ColyseusClient("localhost", "8080");
            await _colyseusClient.ConnectToServer();
            var room = _colyseusClient.JoinRoom("match");
            room.Listen("players/:id", new ListenerPlayers().OnChange);
        }
    }
}