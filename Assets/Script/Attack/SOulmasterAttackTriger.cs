using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOulmasterAttackTriger : MonoBehaviour
{
    public string playerTag = "Player";

    void Start()
    {
        SoulMasterAI[] soulMasterAIs = FindObjectsOfType<SoulMasterAI>();

        foreach (SoulMasterAI soulMasterAI in soulMasterAIs)
        {
            if (soulMasterAI != null)
            {
                soulMasterAI.IfSoulDead();
                soulMasterAI.IfSoulDead();
                soulMasterAI.IfSoulDead();
            }
        }


        Destroy(gameObject);
    }

    void Update()
    {

    }
}
