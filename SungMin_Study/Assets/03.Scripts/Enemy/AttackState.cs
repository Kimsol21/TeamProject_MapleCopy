using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : State
{
    private Enemy enemy;
    
    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
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
            
    }

    
}
