using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveDirection = Input.GetAxis("Horizontal");
        
        
       rb.velocity = new Vector3(horizontalMoveDirection * playerSpeed, rb.velocity.y, playerSpeed);
        
        
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishLine"))
        {
            playerSpeed = 0;
            Time.timeScale = 0;
        }
    }
    public void PlayerMove(float moveDirection, float speed)
    {
        rb.velocity = new Vector3(moveDirection * speed, rb.velocity.y, speed);
    }

}
