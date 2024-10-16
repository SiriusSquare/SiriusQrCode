using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProMain : MonoBehaviour
{
    public GameObject HitEffectPrefab;
    public GameObject CriticalEffectPrefab;
    public string Tag = "enemy";
    public string playerObjectTag = "Player";
    private PlayerStatus playerStatus;
    public float lifetime = 0.5f;
    public float damegedef = 1.0f;
    public float damage;

    void Start()
    {
        
        GameObject playerObject = GameObject.FindWithTag(playerObjectTag);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (playerObject != null)
        {
            
            playerStatus = playerObject.GetComponent<PlayerStatus>();

            if (playerStatus != null)
            {
                
                damage = damegedef + playerStatus.FinalAttackPower;
            }
            else
            {

            }
        }
        else
        {

        }
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            
            EnemyMain enemy = other.GetComponent<EnemyMain>();
            if (enemy != null)
            {
                float CriticalRolls = UnityEngine.Random.Range(0f, 100f);
                if (CriticalRolls <= playerStatus.criticalchance)
                {
                    float SuperCriticalRolls = UnityEngine.Random.Range(0f, 100f);
                    if (SuperCriticalRolls <= playerStatus.criticalchance - 100)
                    {
                        enemy.TakeDamage(damage * 3);
                        GameObject effct = Instantiate(CriticalEffectPrefab, transform.position, transform.rotation);
                    }
                    else
                    {
                        enemy.TakeDamage(damage * 2);
                        GameObject effct = Instantiate(CriticalEffectPrefab, transform.position, transform.rotation);
                    }

                }
                else
                {
                    enemy.TakeDamage(damage);
                    GameObject effct = Instantiate(HitEffectPrefab, transform.position, transform.rotation);
                }
                
            }
        }
    }
}
