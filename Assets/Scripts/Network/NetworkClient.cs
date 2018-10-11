using Colyseus;
using System;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UnityEcsTest.Assets.Scripts.Network
{
    public class NetworkClient
    {

        public static Client client;
        public static Room room;

        public static string serverName = "localhost";
        public static string port = "8080";
        public static string roomName = "match";


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Start()
        {
            Debug.Log("Network Client Start");
            Debug.Log($"Connecting to ws://{serverName}:{port}");
            String uri = "ws://" + serverName + ":" + port;
            client = new Client(uri);
            client.OnClose += (object sender, EventArgs e) => Debug.Log("CONNECTION CLOSED");

            /*
            await client.Connect();
            room = client.Join(roomName);
            room.OnReadyToConnect += (sender, e) => room.Connect();
            room.OnJoin += (sender, e) => Debug.Log("Room Joined");
            room.OnError += (sender, e) =>
            {
                Debug.Log("oops, error ocurred:");
                Debug.Log(e);
            };

            //room.OnMessage += OnData;
            while (true)
            {
                client.Recv();

                yield return 0;
            } 
            */
        }
    }
}