using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSimpleMove : MonoBehaviour
{
    public float speed = 5f;
    public float angle = 0f;

    private Vector2 moveDirection;

    void Awake()
    {
        
        float radians = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    void Update()
    {
        
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
