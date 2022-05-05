using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed, rotationDirection, impulse;
    
    [SerializeField] bool isStick = false;
    Transform stickTransform;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isStick == false)
        {
            gameObject.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime * rotationDirection, 0));
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Opponent"))
        {
            if (isStick)
            {

                Rigidbody rb = collision.collider.attachedRigidbody;
                if (rb != null)
                {

                    Vector3 forceDirection = -collision.gameObject.transform.position - gameObject.GetComponent<MeshCollider>().transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    rb.AddForceAtPosition(forceDirection * impulse/5, transform.position, ForceMode.Impulse);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isStick)
            {

                Rigidbody rb = collision.collider.attachedRigidbody;
                if (rb != null)
                {

                    Vector3 forceDirection = -collision.gameObject.transform.position - gameObject.GetComponent<MeshCollider>().transform.position;
                    forceDirection.y = 0;
                    forceDirection.Normalize();
                    rb.AddForceAtPosition(forceDirection * impulse*10000, transform.position, ForceMode.Impulse);
                }
            }
        }
    }

}
