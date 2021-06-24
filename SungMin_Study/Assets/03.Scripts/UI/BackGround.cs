using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private bool IsBack;

    void Start()
    {
        IsBack = false;
    }
    void Update()
    {
        BackGroundMove();
    }

    private void BackGroundMove()
    {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        if(gameObject.transform.position.x < -4& !IsBack)
        {
            BackGroundCreate();
            Destroy(gameObject, 15.0f);
            IsBack = true;
        }
        
    }

    private void BackGroundCreate()
    {
        Instantiate(gameObject, new Vector3(13, 0, 0), Quaternion.identity);
        IsBack = false;
    }

}
