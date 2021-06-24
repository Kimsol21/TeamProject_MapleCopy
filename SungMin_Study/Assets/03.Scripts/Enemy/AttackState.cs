using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;
    private Animator animator;

    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    public void Update()
    {
        Attack();
    }

    public void OnExit()
    {
    }

    public void Attack()
    {
        if (AttackRange.Instance.isAttacking == true)
        {
            animator.SetBool("isAttack", true);
        }
            
        else
        {
            animator.SetBool("isAttack", false);
        }
            
    }

    
}
