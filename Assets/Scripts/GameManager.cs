using Unity.Entities;
using UnityEngine;

namespace UnityEcsTest.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            var playerEntity = entityManager.CreateEntity(
            );
        }
    }
}