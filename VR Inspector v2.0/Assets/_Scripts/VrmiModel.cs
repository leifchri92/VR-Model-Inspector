using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrmiModel : MonoBehaviour {

	public Material defaultMaterial;

	// Use this for initialization
	void Start () {
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer renderer in renderers) {
			Material[] materialsBuffer = new Material[renderer.materials.Length + 1];
			int i = 0;
			for (; i < renderer.materials.Length; i++) {
				defaultMaterial = renderer.materials [0];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
