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
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(finishLineTransform.position);
    }
  
 

}
