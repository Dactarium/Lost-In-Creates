using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : Interactor
{
	[SerializeField] Player player;

	protected override void Interact(GameObject hit)
	{
		if (player.PlayerInput.select)
		{
			base.Interact(hit);
		}
	}
}
