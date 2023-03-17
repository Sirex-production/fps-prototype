using System;
using UnityEngine;

[ExecuteInEditMode]
public sealed class LightVisualizer : MonoBehaviour
{
	[SerializeField] public Material material;
	
	private void Update()
	{
		if(material == null)
			return;
		
		material.SetVector("_GlobalLightPos", transform.position);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, .3f);
	}
}
