using System;
using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct Health : IComponentData
    {
        public int Value;
    }
    public class HealthComponent : ComponentDataWrapper<Health> { }
}