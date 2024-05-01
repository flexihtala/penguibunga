using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Player[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject
            .FindGameObjectsWithTag("Player")
            .Select(player => player.GetComponent<Player>())
            .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        var temp = transform.position;
        var position = players.First(player => player.isActive).transform.position;
        temp.x = position.x;
        temp.y = position.y;
        transform.position = temp;
    }
}
