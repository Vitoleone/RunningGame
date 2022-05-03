using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutHit : MonoBehaviour
{
    [SerializeField] GameObject[] startPoint;
    Transform startPointTransform;
    int randomStartPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") || other.CompareTag("Opponent"))
        {
            randomStartPoint = Random.Range(0, startPoint.Length - 1);
            startPointTransform = startPoint[randomStartPoint].GetComponent<Transform>();
            other.transform.position = startPointTransform.position;
        }
    }
}
