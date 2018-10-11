using Colyseus;
using System;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace UnityEcsTest.Assets.Scripts.Network
{
    public class ColyseusClient
    {
        public Client Client;
        private string _serverName;
        private string _port;
        private string _serverUri;

        public ColyseusClient(string serverName, string port)
        {
            Debug.Log("ColyseusClient created");
            _serverName = serverName;
            _port = port;
            _serverUri = "ws://" + this._serverName + ":" + this._port;
        }

        public void ConnectToServer()
        {
            Debug.Log($"Connecting to {_serverUri}");


        }
    }
}