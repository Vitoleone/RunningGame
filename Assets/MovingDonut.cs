using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDonut : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject stick;
    Rigidbody rb;
    int direction = -1;
    bool pushed = false;
    void Start()
    {
        rb = stick.GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(pushed == false || rb.velocity == Vector3.zero)
        {
            //rb.AddForce(new Vector3(direction * speed, 0, 0));
            rb.velocity = (new Vector3(direction * speed, 0, 0));
            pushed = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            rb.velocity = Vector3.zero;
            direction = -direction;
            //rb.AddForce(new Vector3(direction * speed, 0, 0));
            rb.velocity = (new Vector3(direction * speed, 0, 0));
        }
    }
   
}
