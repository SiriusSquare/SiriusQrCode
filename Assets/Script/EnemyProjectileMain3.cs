using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMain : MonoBehaviour
{
    public GameObject HitEffectPrefab;
    public GameObject HitPrefab;
    public GameObject NoHitPrefab;
    public bool fading = true;
    public string Tag = "Player";
    public float lifetime = 2f;
    public float damage;

    void Start()
    {
        
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        
        yield return new WaitForSeconds(lifetime);

        
        if (NoHitPrefab != null)
        {
            Instantiate(NoHitPrefab, transform.position, transform.rotation);
        }

        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            
            PlayerHP player = other.GetComponent<PlayerHP>();
            if (player != null)
            {
                
                player.StartCoroutine(player.TakeDamage(damage));

                
                if (HitEffectPrefab != null)
                {
                    Instantiate(HitEffectPrefab, transform.position, transform.rotation);
                }

                
                if (HitPrefab != null)
                {
                    Instantiate(HitPrefab, transform.position, transform.rotation);
                }
            }

            if (fading = true)
            {
                Destroy(gameObject);
            }
            
        }
        else
        {

        }
    }
}
