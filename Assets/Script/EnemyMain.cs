using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMain : MonoBehaviour
{
    public GameObject DeathEffectPrefab;
    public GameObject DeathSummonPrefab;
    public string Tag = "PlayerAttack";
    public string playerTag = "Player";
    public float hp = 3;
    public float damage;
    public float dropCash;
    public Slider hpSlider;
    public BossHpslider bossHpSliderScript;

    private bool isDead = false;

    private void Start()
    {
        
        if (hpSlider != null)
        {
            hpSlider.maxValue = hp;
            hpSlider.value = hp;
            hpSlider.interactable = false;
        }

        
        if (bossHpSliderScript != null)
        {
            bossHpSliderScript.SyncSliders();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        
        hp -= damage;

        if (hpSlider != null)
        {
            hpSlider.value = hp;
        }

        
        if (bossHpSliderScript != null)
        {
            bossHpSliderScript.SyncSliders();
        }

        
        if (hp <= 0)
        {
            isDead = true;
            
            if (DeathEffectPrefab != null)
            {
                Instantiate(DeathEffectPrefab, transform.position, Quaternion.identity);
            }

            if (DeathSummonPrefab != null)
            {
                Instantiate(DeathSummonPrefab, transform.position, Quaternion.identity);
            }

            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
            if (playerObject != null)
            {
                PlayerStatus playerStatus = playerObject.GetComponent<PlayerStatus>();
                if (playerStatus != null)
                {
                    playerStatus.SetCash(playerStatus.Cash + dropCash);
                }
            }

            Destroy(gameObject);
        }
    }
}
