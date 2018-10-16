using UnityEcsTest.Assets.Scripts.Network;
using UnityEcsTest.Assets.Scripts.Network.Listeners.Players;
using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;

namespace UnityEcsTest.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private ColyseusClient _colyseusClient;

        private Dictionary<string, Entity> _players = new Dictionary<string, Entity>();
        
        public async void Start()
        {
            _colyseusClient = new ColyseusClient("localhost", "8080");
            await _colyseusClient.ConnectToServer();
            var room = _colyseusClient.JoinRoom("match");
            room.Listen("players/:id", new ListenerPlayers(_players).OnChange);
        }
    }
}