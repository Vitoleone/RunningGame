using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avoiding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 

        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z), new Vector3(0,0,2f));
    }
}
