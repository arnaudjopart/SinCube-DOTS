using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class ColorGradiantComponentDataAuthoring : MonoBehaviour
{
    public Color m_lowestColor;
    public Color m_apexColor;
    
    private class Baker : Baker<ColorGradiantComponentDataAuthoring>
    {
        public override void Bake(ColorGradiantComponentDataAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new ColorGradiantComponentData
            {
                m_apexColor = new float4(authoring.m_apexColor.r,authoring.m_apexColor.g,authoring.m_apexColor.b,authoring.m_apexColor.a),
                m_lowestColor = new float4(authoring.m_lowestColor.r,authoring.m_lowestColor.g,authoring.m_lowestColor.b,authoring.m_lowestColor.a),
            });
        }
    }
}

public struct ColorGradiantComponentData : IComponentData
{
    public float4 m_lowestColor;
    public float4 m_apexColor;
}