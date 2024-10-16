using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollowAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }


        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (player != null)
        {
            
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

           
            transform.position += direction * moveSpeed * Time.deltaTime;

            
            if (spriteRenderer != null)
            {
                
                if (player.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }
}
