using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRange : MonoBehaviour
{
    private Enemy parent;

    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            parent.SetState(new FollowState());
            parent.P_target = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            parent.SetState(new MoveState());
            parent.P_target = collision.transform;
        }
    }
}
