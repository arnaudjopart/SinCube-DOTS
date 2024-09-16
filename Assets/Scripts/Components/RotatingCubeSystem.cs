using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct RotatingCubeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        /*foreach (var (localTransform, rotateSpeed) 
                 in SystemAPI.Query<RefRW<LocalTransform>,RefRO<RotateSpeed>>())
        {
            var power = 1f;
            for (var i = 0; i < 1000000; i++)
            {
                power *= 2f;
                power /= 2f;
            }
            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime*power);
        }*/

        var job = new RotatingCubeJob
        {
            _deltaTime = SystemAPI.Time.DeltaTime
        };
        job.ScheduleParallel();
    }

    [BurstCompile]
    [WithNone(typeof(RotatingCubeTag))]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float _deltaTime;
       
        public void Execute(ref LocalTransform _transform, in RotateSpeed _rotateSpeed)
        {
            var power = 1f;
            for (var i = 0; i < 1000000; i++)
            {
                power *= 2f;
                power /= 2f;
            }
            _transform = _transform.RotateY(_rotateSpeed.value * _deltaTime*power);

        }
    }
}
