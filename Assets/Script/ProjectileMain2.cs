using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMain2 : MonoBehaviour
{
    public string Tag = "enemy";    // 충돌 대상 태그
    public string playerObjectTag = "Player"; // 플레이어 대상으로 삼을 태그 지정
    private PlayerStatus playerStatus;   // PlayerStatus 스크립트 참조
    public float lifetime = 2f;     // 발사체 지속 시간
    public float damegedef = 5.0f;   // 기본 데미지
    public float damage;             // 계산된 발사 간격

    void Start()
    {
        // Player 태그를 가진 오브젝트를 찾음 
        GameObject playerObject = GameObject.FindWithTag(playerObjectTag);
        
        if (playerObject != null)
        {
            // playerStatus를 가져옴
            playerStatus = playerObject.GetComponent<PlayerStatus>();

            if (playerStatus != null)
            {
                // 데미지를 사용하여 발사체 데미지 설정
                damage = damegedef + playerStatus.FinalAttackPower;
            }
            else
            {

            }
        }
        else
        {

        }
        Destroy(gameObject, lifetime); // 시간이 지난 후 발사체 파괴
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag)) // 만약 태그가 지정한 태그와 일치하면
        {
            // 적에게 데미지를 입힙니다.
            EnemyMain enemy = other.GetComponent<EnemyMain>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // 발사체 파괴
        }
        else
        {
            Debug.Log("태그 불일치: " + other.gameObject.tag);
        }
    }
}
