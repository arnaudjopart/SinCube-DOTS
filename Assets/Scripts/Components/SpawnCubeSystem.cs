using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnCubeSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<PrefabConfig>();
    }

    protected override void OnUpdate()
    {
        /*this.Enabled = false;

        var config = SystemAPI.GetSingleton<PrefabConfig>();

        for (int i = 0; i < 5; i++)
        {
            var entity = EntityManager.Instantiate(config.m_prefabEntity);
            EntityManager.SetComponentData(entity, new LocalTransform
            {
                Position = new float3(UnityEngine.Random.Range(-10, 5f), 0, UnityEngine.Random.Range(-10, 5f)),
                Scale = 1f,
                Rotation = quaternion.identity
            });
        }*/
        
    }
}
