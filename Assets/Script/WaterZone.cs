using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    public GameObject HitEffectPrefab;
    public string Tag = "Player";
    public string EnemyTag = "enemy"; 
    public float lifetime = 2f;
    public float damage;
    public float enemydamage;
    public Transform PlayerSpawnTransform;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        bool HasBossOrFlyChild(Transform obj)
        {
            foreach (Transform child in obj)
            {
                if (child.name == "Boss" || child.name == "Fly")
                {
                    return true;
                }
            }
            return false;
        }

        if (other.CompareTag(Tag)) 
        {

            if (HasBossOrFlyChild(other.transform))
            {
                return;
            }


            PlayerHP player = other.GetComponent<PlayerHP>();
            if (player != null)
            {

                player.StartCoroutine(player.TakeDamage(damage + (player.currentHP / 10)));
               Instantiate(HitEffectPrefab, player.transform.position, transform.rotation);


                player.transform.position = PlayerSpawnTransform.position;
            }
        }
        else if (other.CompareTag(EnemyTag))
        {

            if (HasBossOrFlyChild(other.transform))
            {
                return;
            }


            EnemyMain enemy = other.GetComponent<EnemyMain>();
            if (enemy != null)
            {

                enemy.TakeDamage(enemydamage + (enemy.hpSlider.maxValue / 5));


                Instantiate(HitEffectPrefab, enemy.transform.position, transform.rotation);


                Vector3 randomPosition = new Vector3(
                    Random.Range(-45.0f, 45.0f),
                    Random.Range(-25.0f, 25.0f),
                    PlayerSpawnTransform.position.z
                );
                enemy.transform.position = randomPosition;
            }
        }
    }
}
