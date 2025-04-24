using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    InputController inputs;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] LayerMask groundedRCLayerMask;

    bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<InputController>();
    }

    private void OnEnable()
    {
        inputs.OnJumpEvent += HandleOnJump;
    }

    private void OnDisable()
    {
        inputs.OnJumpEvent -= HandleOnJump;
    }

    void FixedUpdate()
    {
        
        //Origin, direction, distance, collision filter
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedRCLayerMask);
        if(grounded) rb.linearVelocityX = inputs.moveDir * speed;
    }

    private void HandleOnJump(object sender, EventArgs e)
    {
        if(grounded) rb.linearVelocityY = jumpForce;
    }
}
