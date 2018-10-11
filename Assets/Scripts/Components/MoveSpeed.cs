using System;
using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float Value;
    }

    //If Component needs to be used on Prefabs
    //public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>{}
}