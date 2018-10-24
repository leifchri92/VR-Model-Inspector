using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteConfirmation : MonoBehaviour {

	public GameObject[] selections;

	public void HideParent() {
		transform.parent.gameObject.SetActive (false);
	}

	public void Delete() {
		foreach (GameObject selection in selections) {
			Destroy (selection);
		}
		HideParent ();
	}
}
