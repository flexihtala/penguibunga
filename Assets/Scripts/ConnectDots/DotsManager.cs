using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour
{
    public bool isStarted;

    public bool isClicked;

    public HashSet<SpriteRenderer> Tiles = new();

    public Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isClicked = true;
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            foreach (var tile in Tiles)
            {
                tile.color = defaultColor;
            }
        };
    }
}
