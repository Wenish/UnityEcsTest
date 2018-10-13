using System;
using Unity.Entities;
using UnityEngine;

namespace UnityEcsTest.Assets.Scripts.Components
{
    [Serializable]
    public struct NetworkEntity : IComponentData
    {
    }
    public class NetworkEntityComponent : ComponentDataWrapper<NetworkEntity>{}
}