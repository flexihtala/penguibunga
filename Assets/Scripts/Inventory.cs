using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Dictionary<ItemName, Item> PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = new Dictionary<ItemName, Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
