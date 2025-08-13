using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemPanel;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemPanel.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else  //Unused. for removing item/s
            {
                slots[i].ClearSlot();
            }
        }
    }
}
