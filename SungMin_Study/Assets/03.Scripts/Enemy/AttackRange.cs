using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public static AttackRange Instance;
    private Enemy parent;

    public bool isAttacking;
    private float attackTime = 1.0f; //공격 주기
    private bool isAttackState = false;
    private bool isFinished = true;

    private void Start()
    {
        Instance = this;
        parent = GetComponentInParent<Enemy>();        
    }

    private void Update()
    {
        if (isFinished == true && isAttackState)
            StartCoroutine(Attack()); //공격 코루틴 실행
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new AttackState()); //공격 상태에 돌입하기.
            isAttackState = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new FollowState()); // 추격 상태로 돌아가기.
            isAttacking = false;
            isAttackState = false;
            StopCoroutine("Attack"); //공격 코루틴 중지
        }
    }

    IEnumerator Attack() //정상작동.
    {
        isFinished = false;

        isAttacking = true;

        Debug.Log("어택 트루");
        yield return new WaitForSeconds(0.5f); // 공격 애니메이션 진행 시간

        isAttacking = false;

        Debug.Log("어택 펄스");
        yield return new WaitForSeconds(attackTime);

        isFinished = true;
    }
}
