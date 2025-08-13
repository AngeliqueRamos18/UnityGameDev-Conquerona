using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
	//everything about the item variables

	public Text itemName;			//contains item name
	public Image icon;				//contains item sprite
	public Text itemDescription;	//Contains item description

	Item item;
	public void AddItem(Item newItem) 
	{
		item = newItem;

		itemName.text = item.name;
		itemName.enabled = true;
		itemDescription.text = item.description;
		itemDescription.enabled = true;
		icon.sprite = item.icon;
		icon.enabled = true;
	}

	public void ClearSlot() //unused. for removing item/s
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
	}
}

