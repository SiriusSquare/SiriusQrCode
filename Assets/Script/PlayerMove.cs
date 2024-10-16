using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStatus playerStatus;
    public float moveSpeed = 3.0f;
    private float currentmoveSpeed;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private void Start()
    {
        
        playerStatus = GetComponent<PlayerStatus>();

        
        if (playerStatus != null)
        {
            
            currentmoveSpeed = (float)playerStatus.moveSpeed;
        }
        else
        {
        }
    }

    void Update()
    {
        playerStatus = GetComponent<PlayerStatus>();

        
        if (playerStatus != null)
        {
            
            currentmoveSpeed = (float)playerStatus.moveSpeed;
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        if (mousePosition.x < transform.position.x)
        {
            
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (mousePosition.x > transform.position.x)
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        MoveTo(new Vector3(x, y, 0));
    }

    void MoveTo(Vector3 direction)
    {
				moveDirection = direction;
        transform.position += moveDirection * currentmoveSpeed * Time.deltaTime;
    }
}