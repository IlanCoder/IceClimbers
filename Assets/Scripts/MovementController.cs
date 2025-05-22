using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    InputController inputs;
    Rigidbody2D rb;
    AttackController attackController;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] LayerMask groundedRCLayerMask;

    public bool grounded { get; private set; }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<InputController>();
        attackController = GetComponent<AttackController>();
    }

    private void OnEnable()
    {
        inputs.OnJumpEvent += HandleOnJump;
    }

    private void OnDisable()
    {
        inputs.OnJumpEvent -= HandleOnJump;
    }

    void FixedUpdate() {
        //Origin, direction, distance, collision filter
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedRCLayerMask);
        if (attackController.isAttacking) {
            rb.linearVelocityX = 0;
            return;
        }
        rb.linearVelocityX = inputs.moveDir * speed;
    }

    private void HandleOnJump(object sender, EventArgs e) {
        if(grounded && !attackController.isAttacking) rb.linearVelocityY = jumpForce;
    }
}
