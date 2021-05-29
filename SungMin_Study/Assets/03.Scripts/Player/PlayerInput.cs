using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 moveVector; // 이동 관련 벡터
    public Vector2 p_moveVector { get { return moveVector; } }

    private bool isJumping = false;  // 점프중인지 판별
    public bool p_isJumping { get { return isJumping; } set { isJumping = value; } }

    private bool isAttack = false;  // 공격중인지 판별
    public bool p_isAttack { get { return isAttack; } set { isAttack = value; } }

    private bool isFireBallAttack = false;
    public bool p_isFireBallAttack { get { return isFireBallAttack; } set { isFireBallAttack = value; } }


    private void Update() // 프레임마다 입력값 확인
    {
        GetMoveInput(); 
        GetJumpInput(); 
        GetAttackInput();
    }

    private void GetMoveInput() // 좌우 이동
    {
        Vector2 moveInput;
        moveInput.x = Input.GetAxis("Horizontal"); 
        moveVector = moveInput.x * Vector2.right; 
    }

    private void GetJumpInput() // 점프
    {
        if (Input.GetButtonDown("Jump"))
        {
            if ( isJumping == false) // 점프중이 아닐때만
                isJumping = true; // 점프 true로 설정.
        }
    }

    private void GetAttackInput() // 공격
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (isAttack == false)
                isAttack = true; // 공격 true로 설정.
        }

        if (Input.GetKey(KeyCode.W)) //파이어볼 발사
        {
            if(isFireBallAttack == false)
            {
                isFireBallAttack = true;
            }

        }

    }
}
