using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Dictionary<string, GameObject> PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
