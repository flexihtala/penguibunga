using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Dictionary<ItemName, Item> PlayerInventory;

    public static Inventory Instance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = new Dictionary<ItemName, Item>();
    }


    public delegate void OnItemChanged();
    public static OnItemChanged OnItemChangedCallback;

    public static void Add(Item item)
    {
        PlayerInventory[item.itemName] = item;
        if (item.itemName == ItemName.Crowbar)
            GameState.HaveCrowbar = true;
        OnItemChangedCallback?.Invoke ();
    }
    public static void Remove (ItemName itemName)
    {
        PlayerInventory.Remove(itemName);
        OnItemChangedCallback?.Invoke();
    }
}
