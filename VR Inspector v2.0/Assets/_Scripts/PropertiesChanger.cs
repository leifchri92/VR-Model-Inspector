using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class PropertiesChanger : MonoBehaviour
{

    public GameObject selection;

    [SerializeField]
    private List<Material> materials;
    [SerializeField]
    private Material outlineMaterial;

	[SerializeField]
	private ModifyPanel modifyPanel;

	private VRTK_ControllerEvents controllerEvents;
	private bool touchPadIsTouched = false;
	private bool triggerIsPressed = false;

	void Awake() {
		materials.Insert (0, null);
	}

	void OnEnable() {
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
		RemoveOutline (selection);
		selection = null;

		if (controllerEvents != null) {
			controllerEvents.TriggerPressed -= DoTriggerPressed;
			controllerEvents.TriggerReleased -= DoTriggerReleased;
			controllerEvents.TouchpadTouchStart -= DoTouchpadTouchStart;
			controllerEvents.TouchpadTouchEnd -= DoTouchpadTouchEnd;
		}
	}

	private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e) {
		print (touchPadIsTouched);
		triggerIsPressed = true;
	}

	private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e) {
		triggerIsPressed = false;
	}

	private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e) {
		print (triggerIsPressed);
		touchPadIsTouched = true;
	}

	private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e) {
		touchPadIsTouched = false;
	}

	public void ChangeMaterial(Material mat) {
		if (selection == null)
			return;

		Renderer[] renderers = GetRenderers(selection);
		foreach (Renderer renderer in renderers)
		{
			Material[] materialsBuffer = new Material[renderer.materials.Length + 1];
			int i = 0;
			for (; i < renderer.materials.Length; i++)
			{
				materialsBuffer[i] = mat;
			}
			materialsBuffer[i] = outlineMaterial;
			renderer.materials = materialsBuffer;
		}
	}

	public void ChangeIntensity(float value) {
		if (selection == null)
			return;

		Light light = selection.GetComponent<Light> ();
		if (light == null)
			return;

		light.intensity = value;
	}

	public void ChangeRange(float value) {
		if (selection == null)
			return;

		Light light = selection.GetComponent<Light> ();
		if (light == null)
			return;

		light.range = value;
	}

	public void ChooseColor(ColorPicker picker, Image colorImage) {
		picker.onValueChanged.AddListener(color =>
			{
				selection.GetComponent<Light> ().color = color;
				colorImage.color = color;
			});
		picker.CurrentColor = selection.GetComponent<Light> ().color;
	}

	public void ChangeSpotAngle(float value) {
		if (selection == null)
			return;

		Light light = selection.GetComponent<Light> ();
		if (light == null)
			return;

		light.spotAngle = value;
	}

	public void Select() {
		RaycastHit hitInfo;
		if (Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo) && hitInfo.transform.tag == "Transformable")
		{
			Transform target = hitInfo.transform;

			if (selection != target.gameObject) {

				RemoveOutline (selection);

				selection = target.gameObject;

				AddOutline (selection);

				if (selection.GetComponent<Light> () != null) {
					modifyPanel.DisplayLightsPanel ();
				} else {
					materials[0] = selection.GetComponentsInParent<VrmiModel> ()[0].defaultMaterial;
					modifyPanel.materialsPanel.GetComponent<MaterialsPanel> ().SetMaterials (materials);
					modifyPanel.DisplayMaterialsPanel ();
					//materials.RemoveAt (0);
				}
			}

		}
	}

    // Update is called once per frame
    void Update()
    {
        if (touchPadIsTouched && triggerIsPressed)
        {
			Select ();
        }
    }

    void AddOutline(GameObject gameObject)
    {
		if (gameObject == null)
			return;
		
		Renderer[] renderers = GetRenderers (gameObject);
		foreach (Renderer renderer in renderers) {
			Material[] materialsBuffer = new Material[renderer.materials.Length + 1];
			int i = 0;
			for (; i < renderer.materials.Length; i++) {
				materialsBuffer [i] = renderer.materials [i];
			}
			materialsBuffer [i] = outlineMaterial;
			renderer.materials = materialsBuffer;
		}
    }

    void RemoveOutline(GameObject gameObject)
    {
		if (gameObject == null)
			return;
		
		Renderer[] renderers = GetRenderers(gameObject);
		Material defaultMat = null;
		foreach (Renderer renderer in renderers)
		{
			Material[] materialsBuffer = new Material[renderer.materials.Length - 1];
			for (int i = 0; i < renderer.materials.Length-1; i++)
			{
				materialsBuffer[i] = renderer.materials[i];
			}
			renderer.materials = materialsBuffer;
		}

    }

    Renderer[] GetRenderers(GameObject gameObject)
    {
        Renderer[] renderers = gameObject.GetComponents<Renderer>();
		Renderer[] parentRenderers = new Renderer[0];//gameObject.GetComponentsInParent<Renderer>();
		Renderer[] childRenderers = new Renderer[0];//gameObject.GetComponentsInChildren<Renderer>();

        Renderer[] renderersBuffer = new Renderer[renderers.Length + parentRenderers.Length + childRenderers.Length];
        int i = 0;
        for (int j = 0; j < renderers.Length; j++, i++)
        {
            renderersBuffer[i] = renderers[j];
        }
        for (int j = 0; j < parentRenderers.Length; j++, i++)
        {
            renderersBuffer[i] = parentRenderers[j];
        }
        for (int j = 0; j < childRenderers.Length; j++, i++)
        {
            renderersBuffer[i] = childRenderers[j];
        }

        return renderersBuffer;
    }
}
