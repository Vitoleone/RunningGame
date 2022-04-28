using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] bool isHorizontal, isVertical;
    [SerializeField] float obstacleSpeed;
    [SerializeField] GameObject[] startPoint;
    Transform startPointTransform;
    int randomStartPoint;
    void Start()
    {
       
    }

    
    void Update()
    {
       
        if (isHorizontal)
        {
        gameObject.transform.position += new Vector3(obstacleSpeed*Time.deltaTime, 0, 0);
        }
        else if( isVertical)
        {
        gameObject.transform.position += new Vector3(0, obstacleSpeed * Time.deltaTime, 0);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isHorizontal && collision.collider.CompareTag("Wall"))
        {
            obstacleSpeed *= -1;
        }
        else if(isVertical && collision.collider.CompareTag("Ceiling"))
        {
            obstacleSpeed *= -1;
        }
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Opponent"))
        {
            randomStartPoint = Random.Range(0, startPoint.Length - 1);
            startPointTransform = startPoint[randomStartPoint].GetComponent<Transform>();
            collision.collider.transform.position = startPointTransform.position;
        }
    }
}

