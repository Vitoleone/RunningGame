using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStartPoint : MonoBehaviour
{
    [SerializeField] GameObject[] startPoint;
    Transform startPointTransform;
    int randomStartPoint;
    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Opponent"))
        {
            randomStartPoint = Random.Range(0, startPoint.Length - 1);
            startPointTransform = startPoint[randomStartPoint].GetComponent<Transform>();
            collision.collider.transform.position = startPointTransform.position;
        }
    }
}
