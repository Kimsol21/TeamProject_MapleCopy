using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private State currentState;

    private Transform target;
    public Transform P_target { get { return target; } set { target = value; } }

    public AudioClip clip1;//검에 맞는 사운드
    public AudioClip clip2;//파이어볼에 맞는 사운드

    void Start()
    {
        SetState(new MoveState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(State nextState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = nextState;
        currentState.OnEnter(this);
    }

}