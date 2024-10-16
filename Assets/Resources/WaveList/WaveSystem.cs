using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject Zombie1;
    public int SummonZombie1 = 5;
    public float SummonTime1 = 1f;
    public GameObject Zombie2;
    public int SummonZombie2 = 5;
    public float SummonTime2 = 1f;
    public GameObject Zombie3;
    public int SummonZombie3 = 5;
    public float SummonTime3 = 1f;
    public GameObject Zombie4;
    public int SummonZombie4 = 5;
    public float SummonTime4 = 1f;
    public GameObject Zombie5;
    public int SummonZombie5 = 5;
    public float SummonTime5 = 1f;
    public GameObject Zombie6;
    public int SummonZombie6 = 5;
    public float SummonTime6 = 1f;
    public GameObject Zombie7;
    public int SummonZombie7 = 5;
    public float SummonTime7 = 1f;
    public GameObject Zombie8;
    public int SummonZombie8 = 5;
    public float SummonTime8 = 1f;
    public GameObject Zombie9;
    public int SummonZombie9 = 5;
    public float SummonTime9 = 1f;
    public GameObject Zombie10;
    public int SummonZombie10 = 5;
    public float SummonTime10 = 1f;
    public Transform spawntrans;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    void Start()
    {
        StartCoroutine(WaveStart());
    }

    private IEnumerator WaveStart()
    {
        
        if (Zombie1 != null)
        {
            for (int i = 0; i < SummonZombie1; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie1, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime1);
            }
        }

        
        if (Zombie2 != null)
        {
            for (int i = 0; i < SummonZombie2; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie2, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime2);
            }
        }

        
        if (Zombie3 != null)
        {
            for (int i = 0; i < SummonZombie3; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie3, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime3);
            }
        }

        
        if (Zombie4 != null)
        {
            for (int i = 0; i < SummonZombie4; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie4, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime4);
            }
        }

        
        if (Zombie5 != null)
        {
            for (int i = 0; i < SummonZombie5; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie5, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime5);
            }
        }
        
        if (Zombie6 != null)
        {
            for (int i = 0; i < SummonZombie6; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie6, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime6);
            }
        }
        if (Zombie7 != null)
        {
            for (int i = 0; i < SummonZombie7; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie7, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime7);
            }
        }
        if (Zombie8 != null)
        {
            for (int i = 0; i < SummonZombie8; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie8, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime8);
            }
        }
        if (Zombie9 != null)
        {
            for (int i = 0; i < SummonZombie9; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie9, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime9);
            }
        }
        if (Zombie10 != null)
        {
            for (int i = 0; i < SummonZombie10; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    spawntrans.position.z
                );

                Instantiate(Zombie10, randomPosition, spawntrans.rotation);
                yield return new WaitForSeconds(SummonTime10);
            }
        }
        Destroy(gameObject);
    }
}
