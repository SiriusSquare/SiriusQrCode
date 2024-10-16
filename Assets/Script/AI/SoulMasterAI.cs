using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMasterAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float shootingRange = 5f;
    public float cooldownTime = 2f;
    public GameObject projectilePrefab;

    public float projectileSpeed = 5f;
    public Transform shootPoint;
    private SpriteRenderer spriteRenderer;
    private float lastShootTime;
    private Animator animator;
    public float Animationspeed = 1f;
    public float spread = 0f;
    private float spreadrandom;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
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
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (spriteRenderer != null)
            {
                if (player.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }
    public void IfSoulDead()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
    
            Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;


            float spreadRandomAngle = UnityEngine.Random.Range(-spread, spread);


            Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
            Vector3 spreadDirection = spreadRotation * directionToPlayer;

            // 탄막 생성
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

 
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = spreadDirection * projectileSpeed;
            }
        }
    }


}
