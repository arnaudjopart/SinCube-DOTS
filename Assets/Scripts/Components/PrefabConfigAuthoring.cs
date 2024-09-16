using Unity.Entities;
using UnityEngine;

public class PrefabConfigAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject m_prefab;
    [SerializeField] private int m_nbOfLines;
    [SerializeField] private int m_nbOfColumns;


    public class Baker : Baker<PrefabConfigAuthoring>
    {
        public override void Bake(PrefabConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new PrefabConfig
            {
                m_prefabEntity = GetEntity(authoring.m_prefab,TransformUsageFlags.Dynamic),
                m_nbOfLines = authoring.m_nbOfLines,
                m_nbOfColumns = authoring.m_nbOfColumns
            } );
        }
    }
}

public struct PrefabConfig : IComponentData
{
    public Entity m_prefabEntity;
    public int m_nbOfLines;
    public int m_nbOfColumns;
}