using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    private State currentState;

    //public Slider slider;

    private Transform target;
    public Transform P_target { get { return target; } set { target = value; } }

    

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