using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	[SerializeField] Player player;

	[SerializeField] private float rayLength;
	[SerializeField] private float rayThickness;
	private Camera _camera;

	private float hitDistance;
	private GameObject hitObject;

	Color rayColor = Color.red;

	private void Awake()
	{
		_camera = Helpers.Camera;
	}

	private void Update()
	{
		RaycastHit hit;
		Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
		if (Physics.SphereCast(ray, rayThickness, out hit, rayLength))
		{
			hitObject = hit.transform.gameObject;
			hitDistance = hit.distance;
			rayColor = Color.green;
		}
		else
		{
			hitObject = null;
			hitDistance = rayLength;
			rayColor = Color.red;
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (Application.isPlaying)
		{
			Gizmos.color = rayColor;
			Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hitDistance, rayColor);
			Gizmos.DrawWireSphere(_camera.transform.position + _camera.transform.forward * hitDistance, rayThickness);
		}
	}
}
