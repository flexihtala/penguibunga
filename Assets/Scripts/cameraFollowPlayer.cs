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

    // review(27.06.2024): Лишние комменты можно удалить
    // Update is called once per frame
    void Update()
    {
        var temp = transform.position;
        var player = players.FirstOrDefault(player => player.isActive); // review(27.06.2024): можно было использовать GameState.ActivePlayer, наверное
        if (player is null)
            return;
        var position = player.transform.position;
        temp.x = position.x;
        temp.y = position.y;
        transform.position = temp;
    }
}
