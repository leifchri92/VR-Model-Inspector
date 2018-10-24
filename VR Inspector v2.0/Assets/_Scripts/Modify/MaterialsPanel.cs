using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsPanel : MonoBehaviour {

	private List<Material> materials;
	private Material outlineMaterial;

	[SerializeField]
	private GameObject matButtonPrefab;
	[SerializeField]
	private GameObject materialsDisplay;

	public void SetMaterials(List<Material> materials) {
		this.materials = materials;
		PopulateDisplay ();
	}

	void PopulateDisplay() {
		foreach (Transform child in materialsDisplay.transform) {
			Destroy (child.gameObject);
		}
		foreach (Material mat in materials) {
			Texture2D matTex = RuntimePreviewGenerator.GenerateMaterialPreview (mat, PrimitiveType.Sphere, 256, 256);
			GameObject matButton = Instantiate (matButtonPrefab, materialsDisplay.transform);
			matButton.GetComponent<Image> ().sprite = Sprite.Create(matTex, new Rect(0,0,matTex.width,matTex.height),Vector2.zero);
			matButton.GetComponent<MaterialButton> ().myMaterial = mat;
		}
	}
}
