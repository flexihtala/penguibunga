using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventorySlot[] slots;
    
    private void Start()
    {
        Inventory.OnItemChangedCallback += UpdateUI;
        slots = transform.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateUI()
    {
        Debug.Log("Updating UI");
        Debug.Log(Inventory.PlayerInventory);
        var playerInventoryValues = Inventory.PlayerInventory.Values.ToArray();
        for (var i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.PlayerInventory.Count)
            {
                slots[i].AddItem(playerInventoryValues[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}