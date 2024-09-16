using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnSinCubeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PrefabConfig>();
    }

    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        SystemAPI.TryGetSingleton<PrefabConfig>(out var config);

        for (var i = 0; i < config.m_nbOfLines; i++)
        {
            for (int j = 0; j < config.m_nbOfColumns; j++)
            {
                var instance = state.EntityManager.Instantiate(config.m_prefabEntity);
                var transform = state.EntityManager.GetComponentData<LocalTransform>(instance);
                transform.Position = new float3(i, 0, j);
                state.EntityManager.SetComponentData(instance, transform);

                var sinMovement = state.EntityManager.GetComponentData<SinMovementComponentData>(instance);
                sinMovement.m_phase = i+j;
                state.EntityManager.SetComponentData(instance, sinMovement);
            }
        }

    }
}
