using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SinMovementSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SinMovementComponentData>();
    }

    
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (sinMovement, transform) in SystemAPI.Query<RefRO<SinMovementComponentData>, RefRW<LocalTransform>>())
        {
            var position = transform.ValueRO.Position;
            transform.ValueRW.Position = new float3(position.x,1+(float)math.sin(SystemAPI.Time.ElapsedTime+sinMovement.ValueRO.m_phase*0.2f)*2f, position.z);
        }
    }
}
