using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static HashSet<string> PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = new HashSet<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
