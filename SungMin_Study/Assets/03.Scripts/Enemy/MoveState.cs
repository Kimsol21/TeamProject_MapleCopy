using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private Enemy enemy;
    private float originalPosition;
    private int direction = 1;

    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        originalPosition = enemy.transform.position.x;
        enemy.transform.localScale = new Vector3(1, 1, 1);
    }

    void State.Update()
    {
        if (enemy.transform.position.x < originalPosition - 2.0f)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
            direction *= -1;            
        }
        else if (enemy.transform.position.x > originalPosition + 2.0f)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
            direction *= -1;
        }
        enemy.transform.Translate(new Vector3(direction, 0, 0) * 0.01f);
    }

    public void OnExit()
    {
        
    }
}
