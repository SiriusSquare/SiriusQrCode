using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string enemyattackTag = "Enemyattack";
    private PlayerStatus playerStatus;
    public Slider hpSlider;
    public float currentHP;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;

    private void Start()
    {
        
        playerStatus = GetComponent<PlayerStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        if (playerStatus != null)
        {
            
            currentHP = playerStatus.maxHealth;

            
            if (hpSlider != null)
            {
                hpSlider.maxValue = playerStatus.maxHealth;
                hpSlider.value = currentHP;
            }
        }
    }

    private void Update()
    {
        
        if (hpSlider != null)
        {
            hpSlider.maxValue = playerStatus.maxHealth;
            hpSlider.value = currentHP;
            if (currentHP > playerStatus.maxHealth)
            {
                currentHP = playerStatus.maxHealth;
            }
        }
    }

    public void Heal(float amount)
    {
        
        if (playerStatus != null)
        {
            currentHP += amount;
            if (currentHP > playerStatus.maxHealth)
            {
                currentHP = playerStatus.maxHealth;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag) && !isInvincible)
        {
            StartCoroutine(TakeDamage(1));
        }
    }

    public IEnumerator TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(HitColorAnimation());
            currentHP -= damage;

            if (hpSlider != null)
            {
                hpSlider.value = currentHP;
            }

            if (currentHP <= 0)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(playerStatus.invTime);

            isInvincible = false;
        }
    }

    private IEnumerator HitColorAnimation()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
    }
}
