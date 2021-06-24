using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoGameScene()
    {
       SceneManager.LoadScene(1);
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoSuccessScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoFailScene()
    {
        SceneManager.LoadScene(3);
    }
}
