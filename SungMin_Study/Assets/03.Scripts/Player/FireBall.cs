using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float moveSpeed = 6.0f; //총알 속도
    private float lifeTime = 2.0f; //총알 수명

    private void Start()
    {
        Destroy(gameObject, lifeTime); //시작하고 수명끝나면 Destroy!
    }

    private void Update()
    {
        MoveFireBall(); //파이어볼 움직이기
    }

    private void MoveFireBall()
    {
        this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
