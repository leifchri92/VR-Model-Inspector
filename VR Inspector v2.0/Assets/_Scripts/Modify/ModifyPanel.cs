using UnityEngine;
using RuntimeGizmos;

public class ModifyPanel : MonoBehaviour {

    // Modify tools
    [SerializeField]
    private TransformGizmo transformGizmoScript;
    [SerializeField]
    private PropertiesChanger propertiesChangerScript;

    [SerializeField]
    private GameObject modifyPanelExtra;
    [SerializeField]
    private GameObject transformPanel;
    public GameObject materialsPanel;
    [SerializeField]
    private GameObject lightsPanel;
	[SerializeField]
	private GameObject rangeControl;
	[SerializeField]
	private GameObject spotAngleControl;
	[SerializeField]
	private GameObject colorPanel;

    public void OnClickTransformButton() {
		ResetPanels ();

        propertiesChangerScript.enabled = false;

        bool isEnabled = transformGizmoScript.enabled;
        transformGizmoScript.enabled = !isEnabled;
        transformPanel.transform.SetAsLastSibling();
        modifyPanelExtra.SetActive(!isEnabled);
    }

    public void OnClickPropertiesButton() {
        transformGizmoScript.enabled = false;

		propertiesChangerScript.enabled = !propertiesChangerScript.enabled;
		modifyPanelExtra.SetActive(false);
    }

	public void DisplayMaterialsPanel() {
		ResetPanels ();

		materialsPanel.transform.SetAsLastSibling ();
		modifyPanelExtra.SetActive (true);
	}

	public void DisplayLightsPanel() {
		ResetPanels ();

		PropertiesChanger propertiesChanger = (PropertiesChanger)GameObject.FindObjectOfType(typeof(PropertiesChanger));
		Light myLight = propertiesChanger.selection.GetComponent<Light> ();
		LightPropertiesPanel lightPropertyPanel = lightsPanel.GetComponent<LightPropertiesPanel> ();
		lightPropertyPanel.intensitySlider.value = myLight.intensity;
		lightPropertyPanel.intensityInputField.text = myLight.intensity.ToString ();	
		lightPropertyPanel.colorImage.color = myLight.color;
		if (myLight.type != LightType.Directional) {
			rangeControl.SetActive (true);
			lightPropertyPanel.rangeSlider.value = myLight.range;
			lightPropertyPanel.rangeInputField.text = myLight.range.ToString ();
		} 
		if (myLight.type == LightType.Spot) {
			spotAngleControl.SetActive (true);
			lightPropertyPanel.spotAngleSlider.value = myLight.spotAngle;
			lightPropertyPanel.spotAngleInputField.text = myLight.spotAngle.ToString ();
		}
		lightsPanel.transform.SetAsLastSibling ();
		modifyPanelExtra.SetActive (true);
	}

	private void ResetPanels() {
		rangeControl.SetActive (false);
		spotAngleControl.SetActive (false);
		colorPanel.SetActive (false);
	}
}
