using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    private Rigidbody2D rigid;
    private PlayerInput playerInput; // Input Manager

    private float moveSpeed = 4.0f; // 이동 속도
    private float JumpPower = 6.0f; // 점프 파워
    private float doubleJumpPower = 2.6f; //더블 점프 파워
    public int JumpCount = 0; // 점프 몇번했는지 카운트

    private int moveDirection = 1; // 플레이어가 보고있는 방향 체크,  "1이 오른쪽, -1이 왼쪽"
    public int P_moveDirection { get { return moveDirection; } }

    private void Awake()
    {
        Instance = this;
        rigid = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Move(); // 이동
        Jump(); // 점프
        if(BeatRange.Instance.isWin == true)
            SceneManager.LoadScene("SuccessScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // 땅에 닿으면 점프 카운트 0으로 초기화
        {
            playerInput.p_isJumping = false;
            playerInput.p_isDoubleJumping = false;
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
        else if (playerInput.p_isDoubleJumping && JumpCount == 1) //더블점프!
            DoubleJump();
        else return; // 점프할 조건이 안된다면 함수 끝!
    }

    private void DoubleJump()
    {
        if (playerInput.p_moveVector.x >= 0)
            rigid.AddForce(new Vector2(1,2) * doubleJumpPower, ForceMode2D.Impulse); // 플레이어 점프!
        else
            rigid.AddForce(new Vector2(-1, 2) * doubleJumpPower, ForceMode2D.Impulse); // 플레이어 점프!
        JumpCount++; // 카운트 올려주기 ( 다시 점프 못하게 )
    }

    public void Hurt()
    {
        if (MoveState.Instance.direction == 1)
            rigid.AddForce(new Vector2(2, 0) * doubleJumpPower, ForceMode2D.Impulse); //플레이어 넉백
        else
            rigid.AddForce(new Vector2(-2, 0) * doubleJumpPower, ForceMode2D.Impulse); //플레이어 넉백    
    }

    private void Move()
    {
        if (playerInput.p_moveVector.x > 0) // 좌우반전
        {
            moveDirection = 1;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerInput.p_moveVector.x < 0)
        {
            moveDirection = -1;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        this.transform.Translate(playerInput.p_moveVector * moveSpeed * Time.deltaTime); // 플레이어 이동
    }
}
