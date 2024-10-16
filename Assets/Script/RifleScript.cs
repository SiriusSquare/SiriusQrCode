using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject ShotPart;
    public string playerObjectTag = "Player";
    private PlayerStatus playerStatus;
    public float attackRateDef = 1f;
    public float attackRate;
    public float projectileSpeed = 1.0f;
    private bool canShoot = true;
    public float maxammo = 6f;
    public float ammo = 6f;
    public float durationDef = 0.2f;
    public float duration;
    public float durationreal;
    public float reloaddurationDef = 0.2f;
    public float reloadduration;
    public float reloaddurationreal;
    private Animator animator;
    private float projectileRotationX;

    private Transform parentTransform;

    public AudioClip shotSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;

    private void Start()
    {
        if (IsParentPlayer())
        {
            GameObject playerObject = parentTransform.gameObject;

            if (playerObject != null)
            {
                playerStatus = playerObject.GetComponent<PlayerStatus>();

                if (playerStatus != null)
                {
                    attackRate = attackRateDef * playerStatus.FinalAttackSpeed;
                    duration = durationDef / playerStatus.FinalAttackSpeed;
                    reloadduration = reloaddurationDef / playerStatus.FinalAttackSpeed;
                }
            }
        }

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsParentPlayer() && Input.GetMouseButton(0) && canShoot)
        {
            if (playerStatus != null)
            {
                attackRate = attackRateDef * playerStatus.FinalAttackSpeed;
                duration = durationDef / playerStatus.FinalAttackSpeed;
                reloadduration = reloaddurationDef / playerStatus.FinalAttackSpeed;
            }

            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (animator != null)
        {
            durationreal = durationDef * 10 * playerStatus.FinalAttackSpeed;
            reloaddurationreal = reloaddurationDef * 1 * playerStatus.FinalAttackSpeed;

            if (ammo > 0)
            {
                animator.speed = durationreal;
                animator.SetTrigger("Shot");
                ammo--;

                if (audioSource != null && shotSound != null)
                {
                    audioSource.PlayOneShot(shotSound);
                }

                GameObject projectile = Instantiate(projectilePrefab, ShotPart.transform.position, Quaternion.identity);
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Vector3 directionToMouse = (mousePosition - transform.position).normalized;
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = directionToMouse * projectileSpeed;
                }

                yield return new WaitForSeconds(1 / attackRate);
            }
            else
            {
                animator.speed = reloaddurationreal;
                animator.SetTrigger("Reload");

                if (audioSource != null && reloadSound != null)
                {
                    yield return new WaitForSeconds(0.4f / reloaddurationreal);
                    audioSource.PlayOneShot(reloadSound);
                }

                yield return new WaitForSeconds(1 / reloaddurationreal);

                ammo = maxammo;
            }
        }

        canShoot = true;
    }

    private bool IsParentPlayer()
    {
        Transform currentTransform = transform.parent;

        while (currentTransform != null)
        {
            if (currentTransform.CompareTag(playerObjectTag))
            {
                parentTransform = currentTransform;
                return true;
            }

            currentTransform = currentTransform.parent;
        }

        return false;
    }
}
