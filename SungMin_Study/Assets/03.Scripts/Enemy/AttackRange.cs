using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public static AttackRange Instance;
    private Enemy parent;
    public bool isAttacking;
    private float attackTime = 1.0f; //공격 주기

    private void Start()
    {
        Instance = this;
        parent = GetComponentInParent<Enemy>();
    }

    private void Update()
    {
        //if(Corou)
        StartCoroutine("Attack"); //공격 코루틴 실행
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new AttackState()); //공격 상태에 돌입하기.
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new FollowState()); // 추격 상태로 돌아가기.
            isAttacking = false;
            StopCoroutine("Attack"); //공격 코루틴 중지
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackTime); // 공격 애니메이션 진행 시간
        isAttacking = false;
    }
}
