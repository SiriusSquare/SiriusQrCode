using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMain : MonoBehaviour
{
    public GameObject HitEffectPrefab;
    public GameObject CriticalEffectPrefab;
    public GameObject Criticalprefab; 
    public GameObject CriticalSprefab;  
    public string Tag = "enemy";
    public string playerObjectTag = "Player";
    private PlayerStatus playerStatus;
    public float lifetime = 2f;
    public float damegedef = 5.0f;
    public float damage;

    void Start()
    {

        GameObject playerObject = GameObject.FindWithTag(playerObjectTag);
        
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
                        GameObject supereffct = Instantiate(CriticalEffectPrefab, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }
                    else
                    {
                        enemy.TakeDamage(damage * 2);
                        GameObject supeffct = Instantiate(CriticalEffectPrefab, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }

                }
                else
                {
                    enemy.TakeDamage(damage);
                    GameObject effct = Instantiate(HitEffectPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
