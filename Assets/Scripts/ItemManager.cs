using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	private List<Item> items = new List<Item>();

    void OnEnable()
    {
		Events.OnItemSelect += AddItem;
    }

	private void OnDisable()
	{
		Events.OnItemSelect -= AddItem;
	}

	void AddItem(Item item)
	{
		items.Add(item);
		item.transform.SetParent(transform);
		item.transform.SetAsLastSibling();
		item.gameObject.SetActive(false);
	}
}
