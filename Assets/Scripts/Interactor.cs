using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField] protected float rayLength = 5f;
	[SerializeField] protected float rayThickness = 0.2f;
	[SerializeField] protected Transform raySource;

	[SerializeField] private LayerMask interactableLayers;

	private Color rayColor;
	private float hitDistance;

	protected virtual void Update()
	{
		RaycastHit hit;
		Ray ray = new Ray(raySource.position, raySource.forward);
		if (Physics.SphereCast(ray, rayThickness, out hit, rayLength, interactableLayers))
		{
			hitDistance = hit.distance;
			rayColor = Color.green;
			Interact(hit.transform.gameObject);
		}
		else
		{
			hitDistance = rayLength;
			rayColor = Color.red;
		}
	}

	protected virtual void Interact(GameObject hit)
	{
		if (hit.TryGetComponent(out IPickable pickable))
		{
			pickable.PickItem();
		}
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			Gizmos.color = rayColor;
			Debug.DrawRay(raySource.position, raySource.forward * hitDistance, rayColor);
			Gizmos.DrawWireSphere(raySource.position + raySource.forward * hitDistance, rayThickness);
		}
	}
}
