using System;
using UnityEngine;

public class AttackController : MonoBehaviour {
    InputController inputs;
    MovementController movementController;
    [SerializeField] Transform attackBoxesParent;
    [SerializeField] GameObject jumpAttackBox;
    [SerializeField] GameObject groundedAttackBox;

    public bool isAttacking;
        
    void Awake(){
        inputs = GetComponent<InputController>();
        movementController = GetComponent<MovementController>();
    }

    void Start() {
        jumpAttackBox.SetActive(false);
        groundedAttackBox.SetActive(false);
    }

    void OnEnable() {
        inputs.OnAttackEvent += HandleOnAttack;
    }

    private void OnDisable() {
        inputs.OnAttackEvent -= HandleOnAttack;
    }

    private void FixedUpdate() {
        if (isAttacking) return;
        if (inputs.moveDir > 0) attackBoxesParent.localScale = Vector3.one;
        else if (inputs.moveDir < 0) attackBoxesParent.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleOnAttack(object sender, EventArgs e){
        if(movementController.grounded) {
            groundedAttackBox.SetActive(true);
        }
        else {
            jumpAttackBox.SetActive(true);
        }
    }
}
