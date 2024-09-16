using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RotatingCubeTagAuthoring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private class Baker : Baker<RotatingCubeTagAuthoring>
    {

        public override void Bake(RotatingCubeTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotatingCubeTag());


        }
    }
}


public struct RotatingCubeTag : IComponentData
{
    
}