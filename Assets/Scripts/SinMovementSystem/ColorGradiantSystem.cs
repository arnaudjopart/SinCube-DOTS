using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;


public partial struct ColorGradiantSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ColorGradiantComponentData>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (sinMovement,color,renderer) in 
            SystemAPI.Query<
                RefRO<SinMovementComponentData>,
                RefRO<ColorGradiantComponentData>,RefRW<URPMaterialPropertyBaseColor>>())
        {
            renderer.ValueRW.Value = (float4)math.lerp(color.ValueRO.m_lowestColor, color.ValueRO.m_apexColor,
                math.sin(SystemAPI.Time.ElapsedTime+sinMovement.ValueRO.m_phase*.2f));
        }
    }
}
