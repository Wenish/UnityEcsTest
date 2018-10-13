using System;
using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float Value;
    }
    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>{}
}