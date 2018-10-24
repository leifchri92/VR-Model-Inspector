using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialButton : MonoBehaviour {

	public Material myMaterial;

	public void ChangeSelectedObjectMaterial() {
		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		propertiesChanger.ChangeMaterial (myMaterial);
	}
}
