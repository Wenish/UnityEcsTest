using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    public struct PlayerInput : IComponentData
    {
        public float Horizontal;
    }

    //If Component needs to be used on Prefabs
    //public class PlayerInputComponent : ComponentDataWrapper<PlayerInput>{}
}