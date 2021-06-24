using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AttackRange : MonoBehaviour
{
    public static AttackRange Instance;
    private Enemy parent;
    private Animator animator;

    private float EnemyAttackDamage = 20.0f;
    public Slider HP_Slider;
    private float playerMaxHealth = 100; //플레이어 최대 체력
    private float playerCurHealth;
    public bool isPlayerDead = false;
    public bool isPlayerHeart = false;

    public bool isAttacking;
    private float attackTime = 1.0f; //공격 주기
    private bool isAttackState = false;
    private bool isFinished = true;
    public bool StopEnemy = false;

    private void Start()
    {
        Instance = this;
        parent = GetComponentInParent<Enemy>();
        animator = GetComponentInParent<Animator>();

        HP_Slider.maxValue = playerMaxHealth; //슬라이더 최대값 설정
        playerCurHealth = playerMaxHealth; //최근 체력에 최대체력 저장
        HP_Slider.value = playerCurHealth;
    }

    private void Update()
    {
        if (isFinished == true && isAttackState)
            StartCoroutine(Attack()); //공격 코루틴 실행
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new AttackState()); //공격 상태에 돌입하기.
            isAttackState = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.SetState(new FollowState()); // 추격 상태로 돌아가기.
            isAttacking = false;
            isAttackState = false;
            StopCoroutine("Attack"); //공격 코루틴 중지
        }
    }

    IEnumerator Attack() //정상작동.
    {
        isFinished = false;

        isAttacking = true;
        animator.SetBool("isAttack", true);

        PlayerHP_Manage();

        StopEnemy = true;

        yield return new WaitForSeconds(0.5f); // 공격 애니메이션 진행 시간

        StopEnemy = false;

        isAttacking = false;
        animator.SetBool("isAttack", false);

        yield return new WaitForSeconds(attackTime);

        isFinished = true;
    }

    private void PlayerHP_Manage()
    {
        if (playerCurHealth > 0)
        {
            playerCurHealth -= EnemyAttackDamage; //공격받으면 데미지 입게
            HP_Slider.value = playerCurHealth;
            isPlayerHeart = true;
            PlayerMove.Instance.Hurt(); //넉백
        }
        else
        {
            isPlayerDead = true;
            StartCoroutine(LoadGameOverScene()); //체력 다 닳으면 게임오버 씬 출력.
        }
        
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("FailScene");
    }
}
