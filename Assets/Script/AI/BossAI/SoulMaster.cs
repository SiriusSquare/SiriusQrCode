using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMaster : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float shootingRange = 8f;
    private float Soul;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public GameObject projectilePrefab3;
    public GameObject projectilePrefab4;
    public GameObject projectilePrefab5;
    public GameObject SoulPrefab;
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
                if (Soul >= 1972)
                {
                    Soul = 0;
                    StartCoroutine(SoulAttack());
                }
                else
                {
                    int attackRandom = UnityEngine.Random.Range(1, 4);
                    switch (attackRandom)
                    {
                        case 1:
                            StartCoroutine(TeleportAndShoot());
                            break;
                        case 2:
                            StartCoroutine(TeleportAndShoot2());
                            break;
                        case 3:
                            StartCoroutine(TeleportAndShoot3());
                            break;
                    }
                }
                lastShootTime = Time.time;
            }
        }
    }

    IEnumerator SoulAttack()
    {
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.2f);
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.2f);
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.2f);
        Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;

        Quaternion spreadRotation = Quaternion.Euler(0, 0, 30);
        Vector3 spreadDirection = spreadRotation * directionToPlayer;
        Quaternion spreadRotation2 = Quaternion.Euler(0, 0, 0);
        Vector3 spreadDirection2 = spreadRotation2 * directionToPlayer;
        Quaternion spreadRotation3 = Quaternion.Euler(0, 0, -30);
        Vector3 spreadDirection3 = spreadRotation3 * directionToPlayer;

        GameObject projectile = Instantiate(projectilePrefab4, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = spreadDirection * projectileSpeed;
        }
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.4f);
        GameObject projectile2 = Instantiate(projectilePrefab4, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
        if (rb2 != null)
        {
            rb2.velocity = spreadDirection2 * projectileSpeed;
        }
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.4f);
        GameObject projectile3 = Instantiate(projectilePrefab1, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb3 = projectile3.GetComponent<Rigidbody2D>();
        if (rb3 != null)
        {
            rb3.velocity = spreadDirection3 * projectileSpeed;

        }
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
    }
    IEnumerator TeleportAndShoot()
    {
        for (int i = 0; i < 2; i++)
        {
            float TeleportPosX;
            float TeleportPosY;

            do
            {
                TeleportPosX = UnityEngine.Random.Range(-12f, 12f);
                TeleportPosY = UnityEngine.Random.Range(-12f, 12f);
            }
            while (TeleportPosX > -11f && TeleportPosX < 11f && TeleportPosY > -11f && TeleportPosY < 11f);

            transform.position = new Vector3(player.position.x + TeleportPosX, player.position.y + TeleportPosY, transform.position.z);
            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.3f);
            Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;

            Quaternion spreadRotation = Quaternion.Euler(0, 0, 3);
            Vector3 spreadDirection = spreadRotation * directionToPlayer;
            Quaternion spreadRotation2 = Quaternion.Euler(0, 0, -3);
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

            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.4f);
        }

        Vector3 directionToPlayer2 = (player.position - shootPoint.position).normalized;
        GameObject projectile4 = Instantiate(projectilePrefab5, shootPoint.position, Quaternion.identity);
        float bombvelo = UnityEngine.Random.Range(10f, 15f);
        Rigidbody2D rb4 = projectile4.GetComponent<Rigidbody2D>();
        if (rb4 != null)
        {
            rb4.velocity = directionToPlayer2 * bombvelo;
        }

        for (int i = 0; i < 1; i++)
        {
            float SoulPosX;
            float SoulPosY;

            do
            {
                SoulPosX = UnityEngine.Random.Range(-13f, 13f);
                SoulPosY = UnityEngine.Random.Range(-13f, 13f);
            }
            while (SoulPosX > -12f && SoulPosX < 12f && SoulPosY > -12f && SoulPosY < 12f);

            Instantiate(SoulPrefab, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            if (Effect1 != null)
            {
                Instantiate(Effect1, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            }
        }
    }

    IEnumerator TeleportAndShoot2()
    {
        float TeleportPosX;
        float TeleportPosY;

        do
        {
            TeleportPosX = UnityEngine.Random.Range(-13f, 13f);
            TeleportPosY = UnityEngine.Random.Range(-13f, 13f);
        }
        while (TeleportPosX > -12f && TeleportPosX < 12f && TeleportPosY > -12f && TeleportPosY < 12f);

        transform.position = new Vector3(player.position.x + TeleportPosX, player.position.y + TeleportPosY, transform.position.z);
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.6f);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 directionToPlayer2 = (player.position - shootPoint.position).normalized;
                float spreadRandomAngle2 = UnityEngine.Random.Range(-10, 10);
                Quaternion spreadRotation2 = Quaternion.Euler(0, 0, spreadRandomAngle2);
                Vector3 spreadDirection2 = spreadRotation2 * directionToPlayer2;

                GameObject projectile2 = Instantiate(projectilePrefab4, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
                if (rb2 != null)
                {
                    rb2.velocity = spreadDirection2 * 10;
                }

                yield return new WaitForSeconds(0.05f);
            }
            Instantiate(projectilePrefab2, shootPoint.position, Quaternion.identity);
            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.3f);
        }

        for (int i = 0; i < 1; i++)
        {
            float SoulPosX;
            float SoulPosY;

            do
            {
                SoulPosX = UnityEngine.Random.Range(-13f, 13f);
                SoulPosY = UnityEngine.Random.Range(-13f, 13f);
            }
            while (SoulPosX > -12f && SoulPosX < 12f && SoulPosY > -12f && SoulPosY < 12f);

            Instantiate(SoulPrefab, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            if (Effect1 != null)
            {
                Instantiate(Effect1, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            }
        }
    }

    IEnumerator TeleportAndShoot3()
    {
        float TeleportPosX;
        float TeleportPosY;

        do
        {
            TeleportPosX = UnityEngine.Random.Range(-13f, 13f);
            TeleportPosY = UnityEngine.Random.Range(-13f, 13f);
        }
        while (TeleportPosX > -12f && TeleportPosX < 12f && TeleportPosY > -12f && TeleportPosY < 12f);

        transform.position = new Vector3(player.position.x + TeleportPosX, player.position.y + TeleportPosY, transform.position.z);
        if (Effect1 != null)
        {
            Instantiate(Effect1, shootPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 0; j < 1; j++)
        {
            Vector3 directionToPlayer2 = (player.position - shootPoint.position).normalized;
            float spreadRandomAngle2 = UnityEngine.Random.Range(-40, 40);
            Quaternion spreadRotation2 = Quaternion.Euler(0, 0, spreadRandomAngle2);
            Vector3 spreadDirection2 = spreadRotation2 * directionToPlayer2;

            GameObject projectile2 = Instantiate(projectilePrefab3, shootPoint.position, Quaternion.identity);
            Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
            if (rb2 != null)
            {
                rb2.velocity = spreadDirection2 * 7;
            }

            if (Effect1 != null)
            {
                Instantiate(Effect1, shootPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 10; i++)
            {
                Vector3 directionToPlayer1 = (player.position - shootPoint.position).normalized;
                float spreadRandomAngle1 = UnityEngine.Random.Range(0,0);
                Quaternion spreadRotation1 = Quaternion.Euler(0, 0, spreadRandomAngle1);
                Vector3 spreadDirection1 = spreadRotation1 * directionToPlayer1;

                GameObject projectile1 = Instantiate(projectilePrefab4, shootPoint.position, Quaternion.identity);
                Rigidbody2D rb1 = projectile1.GetComponent<Rigidbody2D>();
                if (rb1 != null)
                {
                    rb1.velocity = spreadDirection1 * 20;
                }

                yield return new WaitForSeconds(0.03f);
            }
        }

        for (int i = 0; i < 1; i++)
        {
            float SoulPosX;
            float SoulPosY;

            do
            {
                SoulPosX = UnityEngine.Random.Range(-13f, 13f);
                SoulPosY = UnityEngine.Random.Range(-13f, 13f);
            }
            while (SoulPosX > -12f && SoulPosX < 12f && SoulPosY > -12f && SoulPosY < 12f);

            Instantiate(SoulPrefab, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            if (Effect1 != null)
            {
                Instantiate(Effect1, new Vector3(player.position.x + SoulPosX, player.position.y + SoulPosY, transform.position.z), Quaternion.identity);
            }
        }
    }

    void IfSoulDead()
    {
        Soul++;
    }
}
