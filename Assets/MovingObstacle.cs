using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] bool isHorizontal, isVertical;
    [SerializeField] float obstacleSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isHorizontal)
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
    }
}

