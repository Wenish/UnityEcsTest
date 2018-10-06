using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEcsTest.Assets.Scripts.Components;
using UnityEcsTest.Assets.Scripts.Network;
using UnityEngine;

namespace UnityEcsTest.Assets.Scripts
{
    public class GameManager
    {

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Start()
        {
            var playerPrototype = GameObject.Find("PlayerPrototype");
            var playerLook = playerPrototype.GetComponent<MeshInstanceRendererComponent>().Value;
            Object.Destroy(playerPrototype);
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            var playerArchtype = entityManager.CreateArchetype(
                typeof(PlayerTag),
                typeof(MoveSpeed),
                typeof(Transform),
                typeof(Position),
                typeof(MeshInstanceRenderer)
            );

            var playerEntity = entityManager.CreateEntity(playerArchtype);
            entityManager.SetComponentData(playerEntity, new MoveSpeed { Value = 6 });
            entityManager.SetSharedComponentData(playerEntity, playerLook);
        }
    }
}