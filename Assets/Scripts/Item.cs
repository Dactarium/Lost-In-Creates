using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
	public void PickItem()
	{
		Events.OnItemSelect?.Invoke(this);
	}
}
