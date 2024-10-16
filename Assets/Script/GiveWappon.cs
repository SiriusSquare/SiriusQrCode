using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWeapon : MonoBehaviour
{
    public GameObject prefab;
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(playerTag))
        {
            
            PlayerItemPickup playerItemPickup = other.GetComponent<PlayerItemPickup>();

            if (playerItemPickup != null)
            {
                
                playerItemPickup.PickupWeapon(prefab);
            }

            
            Destroy(gameObject);
        }
    }
}
