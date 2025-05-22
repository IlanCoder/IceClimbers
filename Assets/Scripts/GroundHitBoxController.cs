using UnityEngine;

public class GroundHitBoxController : MonoBehaviour
{
    [SerializeField] AttackController attackController;
    [SerializeField] float AttackDuration;
    float attackStartTime;

    private void OnEnable()
    {
        attackController.isAttacking = true;
        attackStartTime = Time.time;
    }

    private void OnDisable()
    {
        attackController.isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (Time.time - AttackDuration >= attackStartTime) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.gameObject.SetActive(false);
    }
}
