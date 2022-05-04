using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    
    [SerializeField] GameObject finishLine;
    Transform finishLineTransform;
    
    NavMeshAgent nav;
    
    void Start()
    {
        finishLineTransform = finishLine.transform;
       
        nav = GetComponent<NavMeshAgent>();
        //nav.SetDestination(finishLineTransform.position);


    }

    // Update is called once per frame
    void Update()
    {
       
        
            nav.SetDestination(finishLineTransform.position);
        
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            gameObject.SetActive(false);
        }
    }



}
