using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonItem : MonoBehaviour
{
    public string Tag = "Player";  // �浹 ��� �±�
    public float HealthHeal;
    public float currentHealth;

    public float maxHealthStat;
    public float moveSpeedStat;
    public float attackPowerStat;
    public float attackMultiplierStat;
    public float attackSpeedStat;
    public float attackSpeedMultiplierStat;
    public float criticalchanceStat;
    public float CashStat;

    private float currentMoveSpeed;
    private float currentmaxHealthStat;
    private float currentmoveSpeedStat;
    private float currentattackPowerStat;
    private float currentattackMultiplierStat;
    private float currentattackSpeedStat;
    private float currentattackSpeedMultiplierStat;
    private float currentcriticalchanceStat;
    private float currentCash;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag))
        {
            PlayerStatus player = other.GetComponent<PlayerStatus>();
            PlayerHP playerhp = other.GetComponent<PlayerHP>();
            if (player != null)
            {
                float currentHealth = playerhp.currentHP;
                playerhp.Heal(HealthHeal + currentHealth);

                float currentmaxHealth = player.maxHealth;
                player.SetMaxHealth(currentmaxHealth + maxHealthStat);

                float currentMoveSpeed = player.moveSpeed;
                player.SetMoveSpeed(currentMoveSpeed + moveSpeedStat);

                float currentattackPower = player.attackPower;
                player.SetAttackPower(currentattackPower + attackPowerStat);

                float currentattackMultiplierStat = player.attackMultiplier;
                player.SetAttackMultiplier(currentattackMultiplierStat + attackMultiplierStat);

                float currentattackSpeed = player.attackSpeed;
                player.SetAttackSpeed(currentattackSpeed + attackSpeedStat);

                float currentattackSpeedMultiplierStat = player.attackSpeedMultiplier;
                player.SetAttackSpeedMultiplier(currentattackSpeedMultiplierStat + attackSpeedMultiplierStat);

                float currentcriticalchanceStat = player.criticalchance;
                player.Setcriticalchance(currentcriticalchanceStat + criticalchanceStat);

                float currentCash = player.Cash;
                player.SetCash(currentCash + CashStat);
                Destroy(gameObject);
            }

        }
    }
}
