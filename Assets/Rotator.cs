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
        if (isStick)
        {
            Debug.Log("Stick Girdi");
            Rigidbody rb = collision.collider.attachedRigidbody;
            if (rb != null)
            {
                Debug.Log("Stick Girdi2");
                Vector3 forceDirection = -collision.gameObject.transform.position - gameObject.GetComponent<MeshCollider>().transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                rb.AddForceAtPosition(forceDirection * impulse, transform.position, ForceMode.Impulse);
            }
        }
    }

}
