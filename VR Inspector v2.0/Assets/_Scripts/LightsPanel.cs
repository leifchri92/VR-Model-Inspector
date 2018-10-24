using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsPanel : MonoBehaviour {

	[SerializeField]
	private GameObject lightsPanelExtra;
	[SerializeField]
	private GameObject lightSelectionPanel;
	[SerializeField]
	private GameObject lightControlPanel;

	[SerializeField]
	private ModelList lightList;

	public void OnClickAddButton() {
		lightSelectionPanel.transform.SetAsLastSibling ();
		lightsPanelExtra.SetActive (true);
	}

	public void AddLightToScene(GameObject model) {
		GameObject gameObject = Instantiate (model) as GameObject;
		Vector3 camPos = Camera.main.transform.position;
		gameObject.transform.position = new Vector3 (camPos.x, 0, camPos.z + 3);
		gameObject.AddComponent (typeof(VrmiModel));

		lightList.Add (gameObject);
	}
}
