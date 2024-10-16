using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworddef : MonoBehaviour
{
    public GameObject projectilePrefab;  // 발사체 프리팹
    public string playerObjectTag = "Player"; // 플레이어 대상으로 삼을 태그 지정
    private PlayerStatus playerStatus;   // PlayerStatus 스크립트 참조
    public float attackRateDef = 1f;   // 기본 발사 간격
    public float attackRate;             // 계산된 발사 간격
    public float projectileSpeed = 1.0f;  // 발사체 속도
    private bool canShoot = true;        // 발사 가능 여부
    private int combo; // 콤보
    public float durationDef = 0.2f; // 애니메이션 지속 시간
    public float duration;
    public float durationreal; // 애니메이션 지속 시간
    private Animator animator; // Animator 컴포넌트 참조
    private float projectileRotationX;

    private Transform parentTransform; // 부모 Transform을 저장할 변수

    private void Start()
    {
        if (IsParentPlayer())
        {
            GameObject playerObject = parentTransform.gameObject;

            if (playerObject != null)
            {
                playerStatus = playerObject.GetComponent<PlayerStatus>();

                if (playerStatus != null)
                {
                    attackRate = attackRateDef * playerStatus.FinalAttackSpeed;
                    duration = durationDef / playerStatus.FinalAttackSpeed;
                }
            }
        }

        // Animator 컴포넌트 참조 설정
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 부모가 Player 태그를 가진 오브젝트일 때만 발사
        if (IsParentPlayer() && Input.GetMouseButtonDown(0) && canShoot)
        {
            if (playerStatus != null)
            {
                attackRate = attackRateDef * playerStatus.FinalAttackSpeed;
                duration = durationDef / playerStatus.FinalAttackSpeed;
            }

            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (animator != null)
        {
            durationreal = durationDef * 10 * playerStatus.FinalAttackSpeed;

            // 콤보에 따라 애니메이션 트리거 설정
            if (combo == 0)
            {
                animator.speed = durationreal;
                animator.SetTrigger("SwordSwing1tri");
                combo = 1;
            }
            else if (combo == 1)
            {
                animator.speed = durationreal;
                animator.SetTrigger("SwordSwing2tri");
                combo = 0;
            }
        }

        // 발사체를 콤보에 따라 회전하여 생성
        if (combo == 0)
        {
            projectileRotationX = 180.0f;
        }
        else if (combo == 1)
        {
            projectileRotationX = 0.0f;
        }

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(projectileRotationX, 0f, 0f));
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 directionToMouse = (mousePosition - transform.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = directionToMouse * projectileSpeed;
        }

        yield return new WaitForSeconds(1 / attackRate);

        canShoot = true;
    }

    // 부모 오브젝트가 Player 태그를 가지고 있는지 확인하는 함수
    private bool IsParentPlayer()
    {
        Transform currentTransform = transform.parent;

        while (currentTransform != null)
        {
            if (currentTransform.CompareTag(playerObjectTag))
            {
                parentTransform = currentTransform;
                return true;
            }

            currentTransform = currentTransform.parent;
        }

        return false;
    }
}
