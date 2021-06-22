using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    private bool IsPanel;
    void Start()
    {
        IsPanel = false;
    }

    
    void Update()
    {
        StartCoroutine("LoadPanel");
    }

    
    IEnumerator LoadPanel()
    {
        if (Input.GetKeyDown(KeyCode.R)&& !IsPanel)
        {
            panel.gameObject.SetActive(IsPanel);
            IsPanel = true;
            yield return new WaitForSeconds(3.0f);
            
        }
        if (Input.GetKeyDown(KeyCode.R)&&IsPanel)
        {
            panel.gameObject.SetActive(IsPanel);
            IsPanel = false;
            yield return new WaitForSeconds(3.0f);
            
        }
    }
}
