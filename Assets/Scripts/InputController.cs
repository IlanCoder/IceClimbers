using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    InputSystem_Actions inputs;

    public float moveDir;

    public EventHandler OnJumpEvent;

    public EventHandler OnAttackEvent;

    private void OnEnable() {
        if (inputs == null) {
            inputs = new InputSystem_Actions();
            inputs.Player.Move.performed += i => moveDir = i.ReadValue<float>();
            inputs.Player.Jump.performed += i => OnJumpEvent.Invoke(this, EventArgs.Empty);
            inputs.Player.Attack.performed += i => OnAttackEvent.Invoke(this, EventArgs.Empty);
        }
        inputs.Enable();
    }
}
