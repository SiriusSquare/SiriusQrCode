using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAISwordman : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float shootingRange = 5f;
    public float cooldownTime = 2f;
    public GameObject SwordPrefab;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public Transform shootPoint;
    private SpriteRenderer spriteRenderer;
    private float lastShootTime;
    private Animator animator;
    public float Animationspeed = 1f;
    public float SwordAnimationspeed = 1f;
    public float spread = 0f;
    private int combo;

    void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Ensure that there is a GameObject with the 'Player' tag in the scene.");
        }

       
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.speed = Animationspeed;
    }

    void Update()
    {
        if (player != null)
        {
            
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer <= shootingRange)
            {
                
                if (Time.time >= lastShootTime + cooldownTime)
                {
                    StartCoroutine(ShootProjectile());
                    lastShootTime = Time.time;
                }
            }
            else
            {
                
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }

            
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = player.position.x < transform.position.x;
            }
        }
    }

    IEnumerator ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            
            if (combo == 0)
            {
                animator.speed = SwordAnimationspeed;
                animator.SetTrigger("SwordSwing1tri");
                combo = 1;
            }
            else
            {
                animator.speed = SwordAnimationspeed;
                animator.SetTrigger("SwordSwing2tri");
                combo = 0;
            }

            
            Instantiate(SwordPrefab, shootPoint.position, Quaternion.identity);

            
            Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;

            
            float spreadRandomAngle = UnityEngine.Random.Range(-spread, spread);
            Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
            Vector3 spreadDirection = spreadRotation * directionToPlayer;

           
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = spreadDirection * projectileSpeed;
            }

            
            yield return new WaitForSeconds(0.5f);

            
            animator.SetTrigger("Idle");
        }
    }
}
