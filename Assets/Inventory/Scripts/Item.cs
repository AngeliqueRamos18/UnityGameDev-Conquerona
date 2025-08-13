using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")] //MAIN ITEM SCRIPTABLE OBJECT!
public class Item : ScriptableObject
{
	new public string name = "New Item";
	public string description = "Item description";
	public Sprite icon = null;
}
