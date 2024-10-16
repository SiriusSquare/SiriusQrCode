using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCore : MonoBehaviour
{
    public string folderPath = "WaveList";
    public string folderPath2 = "GrassLand";
    private GameObject[] Wave1;
    private GameObject[] Wave2;
    private GameObject[] Wave3;
    private GameObject[] Wave4;
    private GameObject[] Wave5;

    public string PlayerTag = "Player";
    public Transform spawntrans;
    public GameObject BiomeChangeSystemObject;
    public int wavecount = 0;
    public string enemyTag = "Enemy";
    public string WaveStopTag = "WaveStoper";
    private Vector3 originalPosition;
    private bool isWaitingForEnemies = false;

    public GameObject mainobject;
    public GameObject conChest;
    public GameObject pasChest;
    public GameObject weaChest;
    public Transform Chestpos1;
    public Transform Chestpos2;
    public Transform Chestpos3;
    public GameObject musicPrefab;
    public GameObject BossmusicPrefab;
    public GameObject ambientMusicPrefab;

    private AudioSource currentMusicSource;
    private GameObject currentMusic;
    private AudioSource ambientMusicSource;

    private void Start()
    {
        if (BiomeChangeSystemObject == null)
        {
            BiomeChangeSystemObject = GameObject.Find("BiomeChangeSystem");
        }

        Chestpos1 = GameObject.Find("ChestPos1").transform;
        Chestpos2 = GameObject.Find("ChestPos2").transform;
        Chestpos3 = GameObject.Find("ChestPos3").transform;

        originalPosition = transform.position;

        Wave1 = Resources.LoadAll<GameObject>(folderPath + "/" + folderPath2 + "/Wave1");
        Wave2 = Resources.LoadAll<GameObject>(folderPath + "/" + folderPath2 + "/Wave2");
        Wave3 = Resources.LoadAll<GameObject>(folderPath + "/" + folderPath2 + "/Wave3");
        Wave4 = Resources.LoadAll<GameObject>(folderPath + "/" + folderPath2 + "/Wave4");
        Wave5 = Resources.LoadAll<GameObject>(folderPath + "/" + folderPath2 + "/Wave5");

        PlayAmbientMusic();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag) && !isWaitingForEnemies)
        {
            wavecount++;
            StartCoroutine(WaveStart());
        }
    }

    private IEnumerator WaveStart()
    {
        switch (wavecount)
        {
            case 1:
            case 2:
            case 3:
                if (ambientMusicSource != null && ambientMusicSource.isPlaying)
                {
                    ambientMusicSource.Pause();  // 웨이브 시작 시 배경음악 일시정지
                }

                if (currentMusicSource != null)
                {
                    currentMusicSource.Play();
                }
                else
                {
                    PlayMusic(musicPrefab);
                }
                InstantiateWave(Wave1);
                break;
            case 4:
                PlayMusic(musicPrefab);
                InstantiateWave(Wave4);
                break;
            case 5:
                StopMusic();
                PlayMusic(BossmusicPrefab);
                InstantiateWave(Wave5);
                break;
            case 6:
                StopMusic();
                PlayAmbientMusic();
                BiomeChangeSystem biomeChangeSystem = BiomeChangeSystemObject.GetComponent<BiomeChangeSystem>();
                if (biomeChangeSystem != null)
                {
                    GameObject Player = GameObject.FindWithTag(PlayerTag);
                    Player.transform.position = spawntrans.position + new Vector3(0, -5, 0);
                    yield return StartCoroutine(BiomeChangeCoroutine(biomeChangeSystem));
                }
                break;
        }

        transform.position = new Vector3(19721121, 19721121, 19721121);
        isWaitingForEnemies = true;

        while (AreEnemiesRemaining())
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (wavecount < 5 && currentMusicSource != null)
        {
            currentMusicSource.Pause();
        }

        // 웨이브가 끝났을 때 배경음악 재생
        if (wavecount < 5)
        {
            PlayAmbientMusic();  // 배경음악 다시 재생
        }

        if (wavecount == 5)
        {
            StopMusic();
            PlayAmbientMusic();  // 보스 웨이브 끝난 후 배경음악 재생
        }

        SpawnChests();

        transform.position = originalPosition;
        isWaitingForEnemies = false;

        yield return null;
    }

    public IEnumerator BiomeChangeCoroutine(BiomeChangeSystem biomeChangeSystem)
    {
        StopAmbientMusic();  // 바이옴 변경 시 배경음악 완전히 삭제
        yield return StartCoroutine(biomeChangeSystem.BiomeChange());

        if (mainobject != null)
        {
            wavecount = 0;
            Destroy(ambientMusicSource);
            Destroy(mainobject);
        }
    }



    private void PlayMusic(GameObject musicPrefab)
    {
        if (currentMusic != null)
        {
            Destroy(currentMusic);
        }
        currentMusic = Instantiate(musicPrefab, spawntrans.position, spawntrans.rotation);
        currentMusicSource = currentMusic.GetComponent<AudioSource>();
        if (currentMusicSource != null)
        {
            currentMusicSource.Play();
        }
    }

    private void StopMusic()
    {
        if (currentMusic != null)
        {
            Destroy(currentMusic);
            currentMusicSource = null;
        }
    }

    private void PlayAmbientMusic()
    {
        if (ambientMusicSource == null)
        {
            GameObject ambientMusic = Instantiate(ambientMusicPrefab, spawntrans.position, spawntrans.rotation);
            ambientMusicSource = ambientMusic.GetComponent<AudioSource>();
        }

        if (ambientMusicSource != null && !ambientMusicSource.isPlaying)
        {
            ambientMusicSource.Play();
        }
    }

    private void StopAmbientMusic()
    {
        if (ambientMusicSource != null)
        {
            ambientMusicSource.Stop();
            Destroy(ambientMusicSource.gameObject);
            ambientMusicSource = null;
        }
    }

    private void InstantiateWave(GameObject[] wave)
    {
        Instantiate(wave[Random.Range(0, wave.Length)], spawntrans.position, spawntrans.rotation);
    }

    private bool AreEnemiesRemaining()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] WaveStoper = GameObject.FindGameObjectsWithTag(WaveStopTag);

        return enemies.Length > 0 || WaveStoper.Length > 0;
    }

    private void SpawnChests()
    {
        float randomChance1 = Random.Range(0f, 100f);
        float randomChance2 = Random.Range(0f, 100f);
        float randomChance3 = Random.Range(0f, 100f);

        if (randomChance1 <= 30f)
        {
            Instantiate(conChest, Chestpos1.position, Quaternion.identity);
        }
        else if (randomChance1 <= 85f)
        {
            Instantiate(pasChest, Chestpos1.position, Quaternion.identity);
        }
        else
        {
            Instantiate(weaChest, Chestpos1.position, Quaternion.identity);
        }

        if (randomChance2 <= 30f)
        {
            Instantiate(conChest, Chestpos2.position, Quaternion.identity);
        }
        else if (randomChance2 <= 85f)
        {
            Instantiate(pasChest, Chestpos2.position, Quaternion.identity);
        }
        else
        {
            Instantiate(weaChest, Chestpos2.position, Quaternion.identity);
        }

        if (randomChance3 <= 30f)
        {
            Instantiate(conChest, Chestpos3.position, Quaternion.identity);
        }
        else if (randomChance3 <= 85f)
        {
            Instantiate(pasChest, Chestpos3.position, Quaternion.identity);
        }
        else
        {
            Instantiate(weaChest, Chestpos3.position, Quaternion.identity);
        }
    }
}
