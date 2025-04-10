using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    InputController inputs;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<InputController>();
    }

    private void OnEnable()
    {
        inputs.OnJumpEvent += HanldeOnJump;
    }

    private void OnDisable()
    {
        inputs.OnJumpEvent -= HanldeOnJump;
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = inputs.moveDir * speed;
    }


    private void HanldeOnJump(object sender, EventArgs e)
    {
        rb.linearVelocityY = jumpForce;
    }
}
