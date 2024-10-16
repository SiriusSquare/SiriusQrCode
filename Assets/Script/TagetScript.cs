using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        mousePosition.z = transform.position.z;

        
        transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}

