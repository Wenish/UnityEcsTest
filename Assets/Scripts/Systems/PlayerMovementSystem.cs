using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEcsTest.Assets.Scripts.Components;
using UnityEngine;
using Unity.Mathematics;

namespace UnityEcsTest.Assets.Scripts.Systems
{
    public class PlayerMovementSystem : ComponentSystem
    {
        public struct PlayerGroup
        {
            public ComponentDataArray<Position> Position;
            public ComponentDataArray<MoveSpeed> MoveSpeed;
            public readonly int Length;
        }

        [Inject] private PlayerGroup _player;

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;
            for (int i = 0; i < _player.Length; i++)
            {
                var pos = _player.Position[i];

                pos.Value += new float3(
                    Input.GetAxis("Horizontal") * _player.MoveSpeed[i].Value * dt,
                    0,
                    Input.GetAxis("Vertical") * _player.MoveSpeed[i].Value * dt
                );
                
                _player.Position[i] = pos;
            }
        }
    }
}