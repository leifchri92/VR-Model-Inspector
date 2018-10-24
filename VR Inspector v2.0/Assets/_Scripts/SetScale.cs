using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class SetScale : MonoBehaviour {

	[SerializeField]
	private GameObject modelsExtraPanel;
	[SerializeField]
	private GameObject scaleMenu;
	[SerializeField]
	private InputField inputField;
	[SerializeField]
	private GameObject numPanelCanvas;

	[SerializeField]
	private GameObject scalePrefab;

	private Scale scale = null;
	private bool pickingPoints = true;
	private int index = 0;
	private bool mouseDown = false;

	private GameObject selectedObject;

	private VRTK_ControllerEvents controllerEvents;
	private bool touchPadIsTouched = false;
	private bool triggerIsPressed = false;

	void OnEnable() {
		scaleMenu.SetActive (true);	

		controllerEvents = (controllerEvents == null ? GetComponent<VRTK_ControllerEvents>() : controllerEvents);
		if (controllerEvents == null)
		{
			VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
			return;
		}

		//Setup controller event listeners
		controllerEvents.TriggerPressed += DoTriggerPressed;
		controllerEvents.TriggerReleased += DoTriggerReleased;
		controllerEvents.TouchpadTouchStart += DoTouchpadTouchStart;
		controllerEvents.TouchpadTouchEnd += DoTouchpadTouchEnd;
	}
		
	void OnDisable() {
		scaleMenu.SetActive (false);
		numPanelCanvas.SetActive (false);
		modelsExtraPanel.SetActive (false);
		if (scale != null)
			Destroy (scale.gameObject);

		if (controllerEvents != null) {
			controllerEvents.TriggerPressed -= DoTriggerPressed;
			controllerEvents.TriggerReleased -= DoTriggerReleased;
			controllerEvents.TouchpadTouchStart -= DoTouchpadTouchStart;
			controllerEvents.TouchpadTouchEnd -= DoTouchpadTouchEnd;
		}
	}

	private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e) {
		triggerIsPressed = true;
	}

	private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e) {
		triggerIsPressed = false;
	}

	private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e) {
		touchPadIsTouched = true;
	}

	private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e) {
		touchPadIsTouched = false;
	}

	private void PlacePoint() {
		RaycastHit hitInfo;
		if (Physics.Raycast (new Ray(transform.position, transform.forward), out hitInfo) && hitInfo.transform.tag == "Transformable") {
			print (hitInfo.point);

			pickingPoints = true;

			selectedObject = hitInfo.transform.gameObject;

			if (!scale) {
				GameObject scaleObject = Instantiate (scalePrefab, hitInfo.point, Quaternion.identity);
				scale = scaleObject.GetComponent<Scale> ();
				scale.SetPosition (0, hitInfo.point);
				scale.SetPosition (1, hitInfo.point);
			} else {
				scale.SetPosition (index % 2, hitInfo.point);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (triggerIsPressed && touchPadIsTouched) {
			PlacePoint ();
		} else {
			if (pickingPoints)
				index++;
			pickingPoints = false;
		}
	}

	public void Rescale() {
		float input;
		print (inputField.text);
		if(float.TryParse(inputField.text, out input))
		{
			float scaleFactor = input / scale.GetDistance ();
			print (scaleFactor);
			selectedObject.transform.localScale = new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			scale.transform.localScale = new Vector3 (scaleFactor, scaleFactor, scaleFactor);
		}
		else
		{
			Debug.LogError ("SetScale: Invalid input.");
		}
	}

	public void CancelScale() {
		this.enabled = false;
	}


}
