using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetia : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float shootingRange = 8f;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public GameObject projectilePrefab3;
    public GameObject projectilePrefab4;
    public GameObject projectilePrefab5;
    public GameObject projectilePrefab6;
    public GameObject Effect1;
    public GameObject Effect2;
    public GameObject Effect3;
    public float projectileSpeed = 5f;
    public Transform shootPoint;
    private SpriteRenderer spriteRenderer;
    private float lastShootTime;
    private Animator animator;
    public float Animationspeed = 1f;
    public float cooldownTime;

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
                spriteRenderer.flipX = player.position.x < transform.position.x;
            }

            if (distanceToPlayer <= shootingRange && Time.time >= lastShootTime + cooldownTime)
            {
                int attackRandom = UnityEngine.Random.Range(1, 6); // 1 to 4
                switch (attackRandom)
                {
                    case 1:
                        StartCoroutine(ShootPurlse());
                        break;
                    case 2:
                        StartCoroutine(ShootRandomProjectile());
                        break;
                    case 3:
                        StartCoroutine(ShootbluePurlse());
                        break;
                    case 4:
                        StartCoroutine(ShootRailgun());
                        break;
                    case 5:
                        StartCoroutine(ShootRailgun());
                        break;
                    case 6:
                        StartCoroutine(ShootProjectile());
                        break;
                }
                
                lastShootTime = Time.time;
            }
        }
    }

    IEnumerator ShootProjectile()
    {
        if (projectilePrefab1 != null && projectilePrefab2 != null && shootPoint != null)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;
                float spreadRandomAngle = UnityEngine.Random.Range(-360, 360);
                Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
                Vector3 spreadDirection = spreadRotation * directionToPlayer;

                GameObject projectile = Instantiate(projectilePrefab1, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spreadDirection * projectileSpeed;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;
                float spreadRandomAngle = UnityEngine.Random.Range(-360, 360);
                Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
                Vector3 spreadDirection = spreadRotation * directionToPlayer;

                GameObject projectile = Instantiate(projectilePrefab2, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spreadDirection * projectileSpeed;
                }
            }
        }
        yield return null;
    }

    IEnumerator ShootRandomProjectile()
    {
        if (projectilePrefab1 != null && shootPoint != null)
        {
            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.2f);

            if (Effect2 != null)
            {
                Instantiate(Effect2, shootPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.2f);
            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.2f);

            if (Effect2 != null)
            {
                Instantiate(Effect2, shootPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < 2; i++)
            {
                Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;
                float spreadRandomAngle = UnityEngine.Random.Range(-360, 360);
                Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
                Vector3 spreadDirection = spreadRotation * directionToPlayer;

                GameObject projectile = Instantiate(projectilePrefab5, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spreadDirection * 16;
                }

                
                if (Effect1 != null)
                {
                    Instantiate(Effect1, shootPoint.position, Quaternion.identity);
                }

                yield return new WaitForSeconds(0.3f);

                
                spreadRandomAngle = UnityEngine.Random.Range(-360, 360);
                spreadRotation = Quaternion.Euler(0, 0, spreadRandomAngle);
                spreadDirection = spreadRotation * directionToPlayer;

                GameObject projectile2 = Instantiate(projectilePrefab6, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.velocity = spreadDirection * 12;
                }

                
                if (Effect2 != null)
                {
                    Instantiate(Effect2, shootPoint.position, Quaternion.identity);
                }

                yield return new WaitForSeconds(0.15f); // 1초 대기
            }
            yield return new WaitForSeconds(2f);
        }
    }


    IEnumerator ShootPurlse()
    {
        if (projectilePrefab3 != null && shootPoint != null)
        {
            // 첫 번째 투사체 발사
            yield return new WaitForSeconds(0.3f);
            Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab3, shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = directionToPlayer * projectileSpeed;
            }

           
            if (Effect2 != null)
            {
                Instantiate(Effect2, shootPoint.position, Quaternion.identity);
            }

            
            for (int i = 0; i < 7; i++)
            {
                Vector3 directionToPlayer2 = (player.position - shootPoint.position).normalized;

                
                float spreadRandomAngle2 = UnityEngine.Random.Range(-360f, 360f);
                Quaternion spreadRotation2 = Quaternion.Euler(0, 0, spreadRandomAngle2);
                Vector3 spreadDirection2 = spreadRotation2 * directionToPlayer2;

                
                GameObject projectile2 = Instantiate(projectilePrefab2, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.velocity = spreadDirection2 * projectileSpeed;
                }

                yield return new WaitForSeconds(0.07f);
            }
        }
    }
    IEnumerator ShootbluePurlse()
    {
        if (projectilePrefab1 != null && shootPoint != null)
        {

            for (int i = 0; i < 3; i++)
            {
                if (Effect1 != null)
                {
                    Instantiate(Effect1, shootPoint.position, Quaternion.identity);
                }
                Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;

                Quaternion spreadRotation = Quaternion.Euler(0, 0,30);
                Vector3 spreadDirection = spreadRotation * directionToPlayer;
                Quaternion spreadRotation2 = Quaternion.Euler(0, 0, -30);
                Vector3 spreadDirection2 = spreadRotation2 * directionToPlayer;
                Quaternion spreadRotation3 = Quaternion.Euler(0, 0, 0);
                Vector3 spreadDirection3 = spreadRotation3 * directionToPlayer;

                
                GameObject projectile = Instantiate(projectilePrefab1, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spreadDirection * projectileSpeed;
                }
                GameObject projectile2 = Instantiate(projectilePrefab1, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.velocity = spreadDirection2 * projectileSpeed;
                }
                GameObject projectile3 = Instantiate(projectilePrefab1, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb3 = projectile3.GetComponent<Rigidbody2D>();
                if (rb3 != null)
                {
                    rb3.velocity = spreadDirection3 * projectileSpeed;
                }

                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    IEnumerator ShootRailgun()
    {
        if (projectilePrefab2 != null && shootPoint != null)
        {
            for (int i = 0; i < 3; i++)
            {
                float TeleportPosX;
                float TeleportPosY;

                do
                {
                    TeleportPosX = UnityEngine.Random.Range(-10f, 10f);
                    TeleportPosY = UnityEngine.Random.Range(-10f, 10f);
                } 
                while (TeleportPosX > -9f && TeleportPosX < 9f && TeleportPosY > -9f && TeleportPosY < 9f);

                transform.position = new Vector3(player.position.x + TeleportPosX, player.position.y + TeleportPosY, transform.position.z);

                // 이팩트 생성
                if (Effect3 != null)
                {
                    Instantiate(Effect3, shootPoint.position, Quaternion.identity);
                }

                yield return new WaitForSeconds(0.6f);
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;
                    GameObject projectile = Instantiate(projectilePrefab2, shootPoint.position, Quaternion.identity);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.velocity = directionToPlayer * projectileSpeed;
                    }
                    yield return new WaitForSeconds(0.12f);
                }
                yield return new WaitForSeconds(6f);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}