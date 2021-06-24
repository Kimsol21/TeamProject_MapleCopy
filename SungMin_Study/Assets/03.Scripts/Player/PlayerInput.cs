using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 moveVector; // 이동 관련 벡터
    public Vector2 p_moveVector { get { return moveVector; } }

    private bool isJumping = false;  // 점프중인지 판별
    public bool p_isJumping { get { return isJumping; } set { isJumping = value; } }

    private bool isDoubleJumping = false;  // 더블 점프중인지 판별
    public bool p_isDoubleJumping { get { return isDoubleJumping; } set { isDoubleJumping = value; } }

    private bool isAttack = false;  // 공격중인지 판별
    public bool p_isAttack { get { return isAttack; } set { isAttack = value; } }

    private bool isFireBallAttack = false;
    public bool p_isFireBallAttack { get { return isFireBallAttack; } set { isFireBallAttack = value; } }

    public AudioClip clip1; //무기 휘두르는 사운드
    public AudioClip clip2; //파이어볼 나갈 때 사운드
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
        if (isJumping == false && Input.GetButtonDown("Jump"))
            isJumping = true;

        if (isJumping == true && Input.GetButtonDown("Jump"))
        {
            if (PlayerMove.Instance.JumpCount == 1) //여기 두번씩 실행됨.
                isDoubleJumping = true;
        }
    }

    private void GetAttackInput() // 공격
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isAttack == false)
                isAttack = true; // 공격 true로 설정.

            SoundManager.instance.SFXPlay("hit", clip1);
        }

        if (Input.GetKeyDown(KeyCode.W)) //파이어볼 발사
        {
            if (isFireBallAttack == false)
            {
                isFireBallAttack = true;
            }
            SoundManager.instance.SFXPlay("fire", clip2);
        }

    }
}
