using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPanelCanvas : MonoBehaviour {

	[SerializeField]
	private GameObject numPanel;

	private InputField selectedInput;

	public void StartNumpad(InputField input) {
		selectedInput = input;
		numPanel.SetActive (true);
	}

	public void NumPress(Text text) {
		selectedInput.text = selectedInput.text + text.text;
	}

	public void BackPress() {
		if (selectedInput.text.Length < 1)
			return;

		selectedInput.text = selectedInput.text.Remove (selectedInput.text.Length - 1);
	}
}
