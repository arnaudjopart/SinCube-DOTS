using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup),OrderLast = true)]
public partial class InputListenerSystem : SystemBase
{
    private DotsInput m_input;
    private PlayerTag m_playerEntity;

    protected override void OnCreate()
    {
        base.OnCreate();
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();
        m_input = new DotsInput();
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        m_input.Enable();
        m_input.Player.Fire.performed += Shoot;
        
        m_playerEntity = SystemAPI.GetSingleton<PlayerTag>();
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();
        m_input.Disable();
        m_input.Player.Fire.performed -= Shoot;
    }

    protected override void OnUpdate()
    {
        var currentMoveInput = m_input.Player.Move.ReadValue<Vector2>();
        SystemAPI.SetSingleton(new PlayerMoveInput
        {
            value = new float2(currentMoveInput.x,currentMoveInput.y)
        });

        m_input.Player.Fire.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext _obj)
    {
        
    }
}

public struct PlayerMoveInput :IComponentData 
{
    public float2 value { get; set; }
}

public struct PlayerTag : IComponentData
{
}
