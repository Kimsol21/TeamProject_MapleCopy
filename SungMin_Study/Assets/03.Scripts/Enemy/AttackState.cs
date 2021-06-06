using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;
    [SerializeField]
    private float attackTime = 0.3f;

    public void OnEnter(Enemy enemy)
    {

    }

    public void Update()
    {
        //StartCoroutine("Attack");
    }

    public void OnExit()
    {

    }

    IEnumerator Attack()
    {
        yield return null;
    }
}
