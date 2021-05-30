using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    public float attackTime = 0.3f; // 공격 애니메이션 실행 시간

    private bool isAttacking = false;
    public bool p_isAttacking { get { return isAttacking; } }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.p_isAttack == true && isAttacking == false)
            StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackTime); // 공격 애니메이션 진행 시간
        playerInput.p_isAttack = false;
        isAttacking = false;
    }
}