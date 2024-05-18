using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    public Camera camera;
    private CameraFollowPlayer cameraFollowPlayer;

    private void Awake()
    {
        cameraFollowPlayer = camera.GetComponent<CameraFollowPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        return;
        if (other.CompareTag("Player"))
        {
            cameraFollowPlayer.enabled = false;
            camera.transform.position = new Vector3(20, -87, -10);
            camera.orthographicSize = 10;
        }
    }
}
