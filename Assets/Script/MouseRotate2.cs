using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate2 : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update () 
    {
        Vector3 mPosition = Input.mousePosition; 
        Vector3 oPosition = transform.position; 
        mPosition.z = oPosition.z - Camera.main.transform.position.z; 
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        
        if (mPosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree + 180);
        }
        else
        {
            
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        }
    }
}
