using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceFieldProjectile : MonoBehaviour
{
    public GameObject HitEffectPrefab;
    public string Tag = "enemy";
    public string playerObjectTag = "Player";
    private PlayerStatus playerStatus;
    public float lifetime = 0.5f;
    public float damegedef = 1.0f;
    public float damage;
    public float dps;

    void Start()
    {
        
        GameObject playerObject = GameObject.FindWithTag(playerObjectTag);
        
        if (playerObject != null)
        {
            
            playerStatus = playerObject.GetComponent<PlayerStatus>();

            if (playerStatus != null)
            {
                
                damage = damegedef * playerStatus.FinalAttackPower;
                dps = damage * playerStatus.FinalAttackSpeed;
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
                enemy.TakeDamage(dps * 1);
                GameObject effct = Instantiate(HitEffectPrefab,transform.position, transform.rotation);
            }

        }
        else
        {
        }
    }
}
