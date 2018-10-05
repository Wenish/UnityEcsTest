using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    public struct PlayerInput : IComponentData
    {
        public float Horizontal;
    }

    public class PlayerInputComponent : ComponentDataWrapper<PlayerInput>{}
}