using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSelectionPanel : MonoBehaviour {

	[SerializeField]
	private List<GameObject> models;
	private List<GameObject> models0;
	[SerializeField]
	private GameObject modelButtonPrefab;
	[SerializeField]
	private GameObject modelSelectionDisplay;

	public bool useResourceFolder = false;

	void Awake() {
		models0 = GetModels ();
		if (useResourceFolder)
			models = models0;
		PopulateDisplay ();
	}

	private List<GameObject> GetModels() {
		Object[] models = Resources.LoadAll ("Models", typeof(GameObject));
		List<GameObject> modelsTemp = new List<GameObject> ();
		foreach (var m in models) {
			print (m.name);
			modelsTemp.Add (m as GameObject);
		}
		return modelsTemp;
	}

	void PopulateDisplay() {
		foreach (Transform child in modelSelectionDisplay.transform) {
			Destroy (child.gameObject);
		}
		foreach (GameObject model in models) {
			Texture2D matTex = RuntimePreviewGenerator.GenerateModelPreview (model.transform, 256, 256);
			GameObject modelButton = Instantiate (modelButtonPrefab, modelSelectionDisplay.transform);
			modelButton.GetComponent<Image> ().sprite = Sprite.Create(matTex, new Rect(0,0,matTex.width,matTex.height),Vector2.zero);
			ModelButton modelButtonScript = modelButton.GetComponent<ModelButton> ();
			modelButtonScript.myModel = model;
			if (modelButtonScript.isLight) {
				modelButtonScript.nameText.text = model.name;
			}
		}
	}

}
