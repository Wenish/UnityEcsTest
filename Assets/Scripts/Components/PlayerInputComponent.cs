using System;
using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct PlayerInput : IComponentData
    {
        public float Horizontal;
    }
    public class PlayerInputComponent : ComponentDataWrapper<PlayerInput>{}
}