using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
	[SerializeField] private MeshFilter meshFilter;


	private void Update()
	{
		Vector3[] vert = meshFilter.mesh.vertices;
		for (int i = 0; i < vert.Length; i++)
		{
			vert[i].y = WaveManager.Instance.GetWaveHeight(transform.position.x + vert[i].x);
		}

		meshFilter.mesh.vertices = vert;
		meshFilter.mesh.RecalculateNormals();
	}
}
