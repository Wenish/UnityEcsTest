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
        }
        private void OperationAdd(JToken jsonObj)
        {
            Debug.Log(jsonObj);
            string playerId = jsonObj["value"]["id"].ToString();
            float moveSpeed = float.Parse(jsonObj["value"]["moveSpeed"].ToString());
            float positionX = float.Parse(jsonObj["value"]["position"]["x"].ToString());
            float positionY = float.Parse(jsonObj["value"]["position"]["y"].ToString());
            float positionZ = float.Parse(jsonObj["value"]["position"]["z"].ToString());
            var playerEntity = _entityManager.CreateEntity(_archtypePlayer);
            _players.Add(playerId, playerEntity);
            Debug.Log(playerEntity.Index);
            //_entityManager.SetComponentData(playerEntity, new NetworkEntity { Id = playerId });
            _entityManager.SetComponentData(playerEntity, new Position { Value = { x = positionX, y = positionY, z = positionZ} });
            _entityManager.SetComponentData(playerEntity, new MoveSpeed { Value = moveSpeed });
            _entityManager.SetSharedComponentData(playerEntity, _playerLook);
            Debug.Log(_players.Count);
        }
        private void OperationReplace()
        {

        }
        private void OperationRemove()
        {

        }
    }
}