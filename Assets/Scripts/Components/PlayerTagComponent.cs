using System;
using Unity.Entities;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct PlayerTag : IComponentData
    {
    }
    public class PlayerTagComponent : ComponentDataWrapper<PlayerTag>{}
}