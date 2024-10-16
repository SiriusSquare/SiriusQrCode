using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPassive : MonoBehaviour
{
    public string folderPath = "Passive";
    private GameObject[] prefabs;
    private GameObject[] prefabsCommon1;
    private GameObject[] prefabsCommon2;
    private GameObject[] prefabsCommon3;
    private GameObject[] prefabsCommon4;
    private GameObject[] prefabsCommon5;

    private void Start()
    {
        
        prefabs = Resources.LoadAll<GameObject>(folderPath);
        prefabsCommon1 = Resources.LoadAll<GameObject>(folderPath + "/common1");
        prefabsCommon2 = Resources.LoadAll<GameObject>(folderPath + "/common2");
        prefabsCommon3 = Resources.LoadAll<GameObject>(folderPath + "/common3");
        prefabsCommon4 = Resources.LoadAll<GameObject>(folderPath + "/common4");
        prefabsCommon5 = Resources.LoadAll<GameObject>(folderPath + "/common5");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            float randomValue = UnityEngine.Random.Range(0f, 100f);

            
            if (randomValue <= 45f)
            {

                Instantiate(prefabsCommon1[Random.Range(0, prefabsCommon1.Length)], transform.position, Quaternion.identity);
            }
            else if (randomValue <= 70f)
            {

                Instantiate(prefabsCommon2[Random.Range(0, prefabsCommon2.Length)], transform.position, Quaternion.identity);
            }
            else if (randomValue <= 85f)
            {

                Instantiate(prefabsCommon3[Random.Range(0, prefabsCommon3.Length)], transform.position, Quaternion.identity);
            }
            else if (randomValue <= 95f)
            {

                Instantiate(prefabsCommon4[Random.Range(0, prefabsCommon4.Length)], transform.position, Quaternion.identity);
            }
            else
            {

                Instantiate(prefabsCommon5[Random.Range(0, prefabsCommon5.Length)], transform.position, Quaternion.identity);
            }

            
            Destroy(gameObject);
        }
    }
}
