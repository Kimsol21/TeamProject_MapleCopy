using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    private Enemy enemy;

    [SerializeField]
    private float followSpeed = 2.0f;

    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    void State.Update()
    {
         if( AttackRange.Instance.StopEnemy  == false)
            FollowTarget();
    }

    public void OnExit()
    {
        
    }

    private void FollowTarget()
    {
        if (enemy.P_target != null)          
        {
            if(enemy.P_target.position.x > enemy.transform.position.x)
            {
                MoveState.Instance.direction = 1;
                enemy.transform.localScale = new Vector3(1, 1, 1);
            }              
            else 
            {
                MoveState.Instance.direction = -1;
                enemy.transform.localScale = new Vector3(-1, 1, 1);
            }
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, new Vector2(enemy.P_target.position.x, enemy.transform.position.y), followSpeed * Time.deltaTime);
        }
    }
}
