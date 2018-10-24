using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelButton : MonoBehaviour {

	public GameObject myModel;
	public bool isLight;
	public Text nameText;

	public void AddToScene() {
		ModelsPanel modelsPanel = (ModelsPanel)GameObject.FindObjectOfType (typeof(ModelsPanel));

		if (isLight) {
			modelsPanel.AddLightToScene (myModel);
		} else {
			modelsPanel.AddModelToScene (myModel);
		}
	}
}
