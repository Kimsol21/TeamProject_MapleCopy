using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Shooter : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject fireBall;

    private bool isShooting = false;
    [SerializeField]
    private float coolTime = 0.1f; //파이어볼 쿨타임

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.p_isFireBallAttack == true && isShooting == false)
            StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        isShooting = true;       
        Instantiate(fireBall, transform.position, transform.rotation);       
        yield return new WaitForSeconds(coolTime); // 공격 애니메이션 진행 시간
        playerInput.p_isFireBallAttack = false; //이제 w눌르면 다시 Shoot 가능
        isShooting = false;
    }
}
