﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatRange : MonoBehaviour
{

    public AudioClip clip1;//검에 맞는 사운드
    public AudioClip clip2;//파이어볼에 맞는 사운드

    public GameObject enemy1;

    private float enemyCurHealth;
    private float enemyMaxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            enemyCurHealth -= 50;
            SoundManager.instance.SFXPlay("hit", clip2);
        }

        if (collision.tag == "Sword")
        {
            enemyCurHealth -= 25;
            SoundManager.instance.SFXPlay("hit", clip1);
        }
        CheckEnemyDead();
    }




    private void CheckEnemyDead()
    {
        if (enemyCurHealth <= 0)
        {
           //Destroy(this, 0.833f);
            
            StartCoroutine(EnemyDead());
        }
    }

    IEnumerator EnemyDead()
    {
        Destroy(enemy1, 0.5f);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SuccessScene");
    }
}
