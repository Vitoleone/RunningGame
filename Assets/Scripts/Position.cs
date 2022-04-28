using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Position : MonoBehaviour
{
    [SerializeField] List<GameObject> players;
    [SerializeField] GameObject finishLine;
    Transform finishLineTransform;
    [SerializeField] Text positionText;
    List<float> distance;
    string position;
    void Start()
    {
        finishLineTransform = finishLine.transform;
       distance = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
    }
    void ChangePosition()
    {
        for (int i = 0; i < players.Count; i++)
        {
            distance.Add(Vector3.Distance(finishLineTransform.position, players[i].transform.position));
        }
        distance.Sort();
        for (int i = 0; i < distance.Count; i++)
        {
            if (distance[i] == Vector3.Distance(finishLineTransform.position, players[0].transform.position))
            {
                position = (i+1).ToString() +".Sýra";
            }
        }
        distance.Clear();
        positionText.text = position;
    }

    
}
