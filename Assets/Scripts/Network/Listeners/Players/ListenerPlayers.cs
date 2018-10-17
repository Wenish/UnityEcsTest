using Colyseus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEcsTest.Assets.Scripts.Components;
using System.Collections.Generic;

namespace UnityEcsTest.Assets.Scripts.Network.Listeners.Players
{
    public class ListenerPlayers : IRoomListener
    {
        private Dictionary<string, Entity> _players;
        private EntityManager _entityManager;
        private EntityArchetype _archtypePlayer;
        private MeshInstanceRenderer _playerLook;
        public ListenerPlayers(Dictionary<string, Entity> players)
        {
            _players = players;

            var playerPrototype = GameObject.Find("PlayerPrototype");
            _playerLook = playerPrototype.GetComponent<MeshInstanceRendererComponent>().Value;
            Object.Destroy(playerPrototype);
            _entityManager = World.Active.GetOrCreateManager<EntityManager>();

            _archtypePlayer = _entityManager.CreateArchetype(
                typeof(NetworkEntity),
                typeof(PlayerTag),
                typeof(MoveSpeed),
                typeof(Health),
                typeof(Position),
                typeof(MeshInstanceRenderer)
            );
        }

        public void OnChange(DataChange obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonObj = JToken.Parse(jsonString);

            var operation = jsonObj["operation"].ToString();
            if (operation == "add")
            {
                OperationAdd(jsonObj);
            }
            else if (operation == "remove")
            {
                OperationRemove(jsonObj);
            }
            else if (operation == "replace")
            {
                OperationReplace(jsonObj);
            }
        }
        private void OperationAdd(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            string playerId = jsonObj["path"]["id"].ToString();
            float moveSpeed = float.Parse(jsonObj["value"]["moveSpeed"].ToString());
            int health = int.Parse(jsonObj["value"]["health"].ToString());
            float positionX = float.Parse(jsonObj["value"]["position"]["x"].ToString());
            float positionY = float.Parse(jsonObj["value"]["position"]["y"].ToString());
            float positionZ = float.Parse(jsonObj["value"]["position"]["z"].ToString());
            var player = _entityManager.CreateEntity(_archtypePlayer);
            _players.Add(playerId, player);
            _entityManager.SetComponentData(player, new Position { Value = { x = positionX, y = positionY, z = positionZ } });
            _entityManager.SetComponentData(player, new MoveSpeed { Value = moveSpeed });
            _entityManager.SetComponentData(player, new Health { Value = health });
            _entityManager.SetSharedComponentData(player, _playerLook);
        }
        private void OperationReplace(JToken jsonObj)
        {
            Debug.Log("Player Replace");
            Debug.Log(jsonObj);
        }
        private void OperationRemove(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            string playerId = jsonObj["path"]["id"].ToString();
            var player = _players[playerId];
            _entityManager.DestroyEntity(player);
        }
    }
}