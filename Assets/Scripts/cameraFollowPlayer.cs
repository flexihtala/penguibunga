using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var temp = transform.position;
        var position = player.transform.position;
        temp.x = position.x;
        temp.y = position.y;
        transform.position = temp;
    }
}
