using Unity.Entities;
using UnityEngine;

public class SinMovementComponentAuthoring : MonoBehaviour
{
    public float m_amplitude;
    public float m_frequency;

    private class Baker : Baker<SinMovementComponentAuthoring>
    {
        public override void Bake(SinMovementComponentAuthoring _authoring)
        {
            var entity = GetEntity(_authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new SinMovementComponentData
            {
                m_amplitude = _authoring.m_amplitude,
                m_frequency = _authoring.m_frequency,
                
            });
        }
    }
}

internal struct SinMovementComponentData : IComponentData
{
    public float m_amplitude;
    public float m_frequency;
    public int m_phase;
}
