using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextShowScript : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;
    [SerializeField] private WaveCore Normal;
    [SerializeField] public TextMeshProUGUI CashText;
    [SerializeField] public TextMeshProUGUI AttackText;
    [SerializeField] public TextMeshProUGUI AttackSpeedText;
    [SerializeField] public TextMeshProUGUI SpeedText;
    [SerializeField] public TextMeshProUGUI CriticalText;
    [SerializeField] public TextMeshProUGUI CalamityText;
    [SerializeField] public TextMeshProUGUI EnemyLeftText;
    [SerializeField] public TextMeshProUGUI WaveText;
    public string enemyTag = "enemy";
    private float Cashint;
    private float Attackint;
    private float AttackSpeedint;
    private float Speedint;
    private float Criticalint;
    private float enemiesint;
    private float Waveint;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("PlayerStatus component is missing from this GameObject.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            
            Cashint = player.Cash;
            Attackint = player.FinalAttackPower;
            AttackSpeedint = player.FinalAttackSpeed;
            Speedint = player.moveSpeed;
            Criticalint = player.criticalchance;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

           
            WaveCore currentWaveCore = GameObject.FindGameObjectWithTag("WaveCore").GetComponent<WaveCore>();

            
            CashText.text = $"<size=50>Cash : </size>\n<size=100>{Cashint}</size>";
            AttackText.text = $"<size=50>Attack Power : </size>\n<size=50>{Attackint}</size>";
            AttackSpeedText.text = $"<size=50>Attack Speed : </size>\n<size=50>{AttackSpeedint}</size>";
            SpeedText.text = $"<size=50>Move Speed : </size>\n<size=50>{Speedint}</size>";
            CriticalText.text = $"<size=50>Critical Chance : </size>\n<size=50>{Criticalint}%</size>";

            
            enemiesint = enemies.Length;
            if (enemiesint < 0)
            {
                enemiesint = 0;
            }
            EnemyLeftText.text = $"Enemies Left : {enemiesint}";

            
            if (currentWaveCore != null)
            {
                Waveint = currentWaveCore.wavecount;
                WaveText.text = $"Wave : {Waveint}";
            }
        }
    }
}
