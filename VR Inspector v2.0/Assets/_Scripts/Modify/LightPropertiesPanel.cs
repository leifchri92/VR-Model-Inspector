using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPropertiesPanel : MonoBehaviour {

	public Slider intensitySlider;
	public InputField intensityInputField;
	public Image colorImage;
	public Slider rangeSlider;
	public InputField rangeInputField;
	public Slider spotAngleSlider;
	public InputField spotAngleInputField;

	[SerializeField]
	private GameObject colorPanel;

	public void OnChangeIntensitySlider(Slider slider) {
		ChangeIntensity (slider.value);
		intensityInputField.text = slider.value.ToString ();
	}
	public void OnChangeIntensityInput(InputField inputField) {
		float value;
		if (float.TryParse (inputField.text, out value)) {
			ChangeIntensity (value);
			intensitySlider.value = value;
		}
	}
	void ChangeIntensity(float value) {
		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		propertiesChanger.ChangeIntensity (value);
	}

	public void OnClickColor() {
		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		propertiesChanger.ChooseColor (colorPanel.GetComponent<ColorPicker> (), colorImage);
		colorPanel.SetActive (true);
	}

	public void OnChangeRangeSlider(Slider slider) {
		ChangeRange (slider.value);
		rangeInputField.text = slider.value.ToString ();
	}
	public void OnChangeRangeInput(InputField inputField) {
		float value;
		if (float.TryParse (inputField.text, out value)) {
			ChangeRange (value);
			rangeSlider.value = value;
		}
	}
	public void ChangeRange(float value) {
		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		propertiesChanger.ChangeRange (value);
	}

	public void OnChangeSpotAngleSlider(Slider slider) {
		ChangeSpotAngle (slider.value);
		spotAngleInputField.text = slider.value.ToString ();
	}
	public void OnChangeSpotAngleInput(InputField inputField) {
		float value;
		if (float.TryParse(inputField.text, out value)) {
			ChangeSpotAngle (value);
			spotAngleSlider.value = value;
		}
	}
	void ChangeSpotAngle(float value) {
		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		propertiesChanger.ChangeSpotAngle (value);
	}
}
