using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationPlatform : MonoBehaviour
{
    public float rotationSpeed, rotationDirection, impulse;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * rotationDirection));

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(rotationSpeed * -rotationDirection * impulse, 0, 0), ForceMode.Acceleration);


        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Acceleration);


        }
    }
}
