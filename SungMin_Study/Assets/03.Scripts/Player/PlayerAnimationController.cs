using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    private PlayerAttack playerAttack;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        ControllerAnimation();
    }

    private void ControllerAnimation()
    {
        if (playerInput.p_moveVector.x != 0) //걷기 애니메이션
            animator.SetBool("walk", true);
        else animator.SetBool("walk", false);

        if (playerInput.p_isJumping == true) //점프 애니메이션
            animator.SetBool("jump", true);
        else animator.SetBool("jump", false);

        if (playerAttack.p_isAttacking == true) //공격 애니메이션
            animator.SetBool("attack", true);
        else animator.SetBool("attack", false);

        if (AttackRange.Instance.isPlayerDead == true) //죽음 애니메이션
            animator.SetBool("dead", true);

        if (AttackRange.Instance.isPlayerHeart == true) //피격 애니메이션
        {
            animator.SetTrigger("Heart");
            AttackRange.Instance.isPlayerHeart = false;
        }
            
    }
}
