using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	#region Singleton 
	// keeps one instance of inventory running
	public static Inventory instance;
	void Awake() 
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of inventory found!");
			return;
		}
		instance = this;
	}

	public List<Item> items = new List<Item>();

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public void Add(Item item)
	{
		items.Add(item);

		if (onItemChangedCallback !=null)
			onItemChangedCallback.Invoke();
	}

	public void Remove(Item item) //Unused. For removing item/s
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
