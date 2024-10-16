using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject shotPart;
    public string playerObjectTag = "Player";
    private PlayerStatus playerStatus;

    public float projectileSpeed = 1.0f;
    private bool canShoot = true;
    public float maxEnergy = 3f;
    public float currentEnergy;
    public float energyRechargeRate = 5f;
    public float attackCooldown = 0.2f;

    private void Start()
    {
        
        GameObject playerObject = GameObject.FindWithTag(playerObjectTag);

        if (playerObject != null)
        {
            
            playerStatus = playerObject.GetComponent<PlayerStatus>();
        }

        currentEnergy = maxEnergy;
        StartCoroutine(RechargeEnergy());
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && canShoot && currentEnergy > 0) 
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        // 발사체 생성 및 발사
        GameObject projectile = Instantiate(projectilePrefab, shotPart.transform.position, Quaternion.identity);
        projectile.transform.SetParent(transform);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 directionToMouse = (mousePosition - transform.position).normalized;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = directionToMouse * projectileSpeed;
        }

        currentEnergy--;

        
        yield return new WaitForSeconds(attackCooldown);

        canShoot = true;
    }

    private IEnumerator RechargeEnergy()
    {
        while (true)
        {
            if (currentEnergy < maxEnergy)
            {
                currentEnergy += 1f;
            }

            
            yield return new WaitForSeconds(energyRechargeRate);
        }
    }
}
