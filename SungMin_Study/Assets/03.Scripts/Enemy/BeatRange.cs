using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatRange : MonoBehaviour
{
    public static BeatRange Instance;
    public AudioClip clip1;//검에 맞는 사운드
    public AudioClip clip2;//파이어볼에 맞는 사운드
    private Animator animator;

    public bool isWin = false;

    public GameObject enemy1;

    public float enemyCurHealth;
    private float enemyMaxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        Instance = this;
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
            //enemyCurHealth -= 50;
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
        Destroy(enemy1);
        isWin = true;
        yield return new WaitForSeconds(2.0f);
        isWin = true;
        SceneManager.LoadScene("SuccessScene");
    }
}
