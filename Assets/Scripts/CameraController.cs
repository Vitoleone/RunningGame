using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] GameObject player;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + 6.5f, player.transform.position.z - 12.78f);
    }
}
