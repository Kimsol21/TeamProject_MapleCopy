using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float moveSpeed = 5.0f; //총알 속도 == 사거리
    private float lifeTime = 2.0f; //총알 수명
    private int myDirection;
    private float DestroyAnimPlayTime = 0.5f; //폭파 에니메이션 재생 시간.
    private Animator animator;
    private bool isExplode = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myDirection = PlayerMove.Instance.P_moveDirection;
        Destroy(gameObject, lifeTime); //시작하고 수명끝나면 Destroy!
    }

    private void Update()
    {
        if (isExplode == false)
            MoveFireBall(); //파이어볼 움직이기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 땅에 닿으면 점프 카운트 0으로 초기화
        {
            isExplode = true;
            animator.SetTrigger("isExplode");
            Destroy(gameObject, DestroyAnimPlayTime);
        }
    }

    private void MoveFireBall()
    {
        if(myDirection == 1) //플레이어가 오른쪽을 볼때
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (myDirection == -1) //플레이어가 왼쪽을 볼때
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
