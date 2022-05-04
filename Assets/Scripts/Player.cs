using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    Rigidbody rb;
    float lastFrameFingerPositionx;
    float moveFactorX;
    [SerializeField]float swerveSpeed;
    [SerializeField] GameObject paintableWall;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", playerSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveDirection = Input.GetAxis("Horizontal");
        
        if(Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionx = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionx;
            lastFrameFingerPositionx = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
        }
       //rb.velocity = new Vector3(playerSpeed, rb.velocity.y, playerSpeed);
        transform.Translate(moveFactorX * Time.deltaTime * swerveSpeed, 0, playerSpeed);
        
        
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishLine"))
        {
            playerSpeed = 0;
            swerveSpeed = 0;
            GameObject.Find("GameController").GetComponent<Position>().enabled = false;
            animator.SetFloat("speed", playerSpeed);
            animator.SetBool("isVictory", true);
            other.gameObject.SetActive(false);
            paintableWall.SetActive(true);
        }
    }
    public void PlayerMove(float moveDirection, float speed)
    {
        rb.velocity = new Vector3(moveDirection * speed, rb.velocity.y, speed);
    }

}
