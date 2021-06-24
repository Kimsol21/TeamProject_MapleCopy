using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public static MoveState Instance;
    private Enemy enemy;
    private float originalPosition;
    public int direction = 1;

    public void OnEnter(Enemy enemy)
    {
        Instance = this;

        this.enemy = enemy;
        originalPosition = enemy.transform.position.x;
        enemy.transform.localScale = new Vector3(1, 1, 1);
    }

    void State.Update()
    {
        Move();        
    }

    public void OnExit()
    {
        
    }

    private void Move()
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
}
