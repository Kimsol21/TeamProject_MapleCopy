using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private PlayerInput playerInput; // Input Manager

    private float moveSpeed = 4.0f; // 이동 속도
    private float JumpPower = 6.0f; // 점프 파워
    private int JumpCount = 0; // 점프 몇번했는지 카운트

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Move(); // 이동
        Jump(); // 점프
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // 땅에 닿으면 점프 카운트 0으로 초기화
        {
            playerInput.p_isJumping = false;
            JumpCount = 0;
        }
    }

    private void Jump()
    {
        if (playerInput.p_isJumping == true && JumpCount < 1) // 점프카운트가 0이고 인풋값 받았을때
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse); // 플레이어 점프!
            JumpCount++; // 카운트 올려주기 ( 다시 점프 못하게 )
        }
        else return; // 점프할 조건이 안된다면 함수 끝!
    }

    private void Move()
    {
        if(playerInput.p_isAttack == false)
        {
            if (playerInput.p_moveVector.x > 0) // 좌우반전
                this.transform.localScale = new Vector3(1, 1, 1);
            else if (playerInput.p_moveVector.x < 0)
                this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(playerInput.p_moveVector * moveSpeed * Time.deltaTime); // 플레이어 이동
        }      
    }
}
