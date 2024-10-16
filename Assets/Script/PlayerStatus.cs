using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float moveSpeed = 5f;
    public float attackPower = 10f;
    public float attackMultiplier = 1f;
    public float attackSpeed = 1f;
    public float attackSpeedMultiplier = 1f;
    public float criticalchance = 0f;
    public float invTime= 1.0f;
    public float Cash = 1.0f;

    public float FinalAttackPower
    {
        get { return attackPower * attackMultiplier; }
    }

    public float FinalAttackSpeed
    {
        get { return attackSpeed * attackSpeedMultiplier; }
    }

    
    void Start()
    {
       
    }


    public void SetMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public void SetAttackPower(float newAttackPower)
    {
        attackPower = newAttackPower;
    }

    public void SetAttackMultiplier(float newAttackMultiplier)
    {
        attackMultiplier = newAttackMultiplier;
    }

    public void SetAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
    }

    public void SetAttackSpeedMultiplier(float newAttackSpeedMultiplier)
    {
        attackSpeedMultiplier = newAttackSpeedMultiplier;
    }

    public void Setcriticalchance(float newcriticalchance)
    {
        criticalchance = newcriticalchance;
    }

    public void SetinvTimer(float newinvTime)
    {
        invTime = newinvTime;
    }
    public void SetCash(float newCash)
    {
        Cash = newCash;
        if (Cash >= 9999999)
        {
            Cash = 9999999;
        }
    }

    void Update()
    {
    }
}

