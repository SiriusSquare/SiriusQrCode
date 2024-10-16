using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeChangeSystem : MonoBehaviour
{
    public string folderPath = "Biome"; // Resources 폴더 내 경로
    private GameObject[] Biome;
    private GameObject[] Biometier1;
    private GameObject[] Biometier2;
    private GameObject[] Biometier3;
    private GameObject[] Biometier4;
    private GameObject[] Biometier5;
    public float level;

    private void Start()
    {
        level = 1;

        // 지정된 경로에서 모든 프리팹 로드
        Biome = Resources.LoadAll<GameObject>(folderPath);
        Biometier1 = Resources.LoadAll<GameObject>(folderPath + "/Tier 1"); 
        Biometier2 = Resources.LoadAll<GameObject>(folderPath + "/Tier 2");
        Biometier3 = Resources.LoadAll<GameObject>(folderPath + "/Tier 3");
        Biometier4 = Resources.LoadAll<GameObject>(folderPath + "/Tier 4");
        Biometier5 = Resources.LoadAll<GameObject>(folderPath + "/Tier 5");
    }

    // BiomeChange 메서드를 코루틴으로 변경
    public IEnumerator BiomeChange()
    {
        if (level <= 1f)
        {
            Instantiate(Biometier1[Random.Range(0, Biometier1.Length)], transform.position, Quaternion.identity);
        }
        else if (level <= 2f)
        {
            Instantiate(Biometier2[Random.Range(0, Biometier2.Length)], transform.position, Quaternion.identity);
        }
        else if (level <= 3f)
        {
            Instantiate(Biometier3[Random.Range(0, Biometier3.Length)], transform.position, Quaternion.identity);
        }
        else if (level <= 4f)
        {
            Instantiate(Biometier4[Random.Range(0, Biometier4.Length)], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Biometier5[Random.Range(0, Biometier5.Length)], transform.position, Quaternion.identity);
        }

        level += 1;

        // 코루틴이 종료되었음을 알리기 위해 null 반환
        yield return null;
    }
}
