using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveDirection = Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(horizontalMoveDirection*playerSpeed*Time.deltaTime, 0, playerSpeed * Time.deltaTime);
        
    }
}
