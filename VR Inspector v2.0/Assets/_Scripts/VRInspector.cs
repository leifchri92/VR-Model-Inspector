using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeGizmos;

public class VRInspector : MonoBehaviour {

    // Modify tools
	[SerializeField]
	private TransformGizmo transformGizmoScript;
    [SerializeField]
    private PropertiesChanger propertiesChangerScript;

    [SerializeField]
    private GameObject modifyPanelExtra;
    [SerializeField]
    private GameObject transformPanel;
    [SerializeField]
    private GameObject materialsPanel;
    [SerializeField]
    private GameObject lightsPanel;

    public void ToggleTransformTool() {
        propertiesChangerScript.enabled = false;

        bool isEnabled = transformGizmoScript.enabled;
        transformGizmoScript.enabled = !isEnabled;
        transformPanel.transform.SetAsLastSibling();
        modifyPanelExtra.SetActive(!isEnabled);
    }

    public void TogglePropertiesTool() {
        transformGizmoScript.enabled = false;

        propertiesChangerScript.enabled = !propertiesChangerScript.enabled;
    }

	public void AddLightToScene(GameObject prefab) {
		GameObject gameObject = Instantiate (prefab) as GameObject;
		Vector3 camPos = Camera.main.transform.position;
		gameObject.transform.position = new Vector3 (camPos.x, 1, camPos.z + 3);
	}

	public void AddModelToScene(GameObject prefab) {
		GameObject gameObject = Instantiate (prefab) as GameObject;
		ResizeMeshToUnit (gameObject);
		Vector3 camPos = Camera.main.transform.position;
		gameObject.transform.position = new Vector3 (camPos.x, 0, camPos.z + 3);
	}

	void ResizeMeshToUnit(GameObject t) {
		MeshFilter mf = t.GetComponent<MeshFilter>();
		if (mf == null)
			return;
		Mesh mesh = mf.sharedMesh;

		//***Set this to renderer bounds instead of mesh bounds***
		Bounds bounds = t.GetComponent<Renderer>().bounds;

		float size = bounds.size.x;
		if (size < bounds.size.y)
			size = bounds.size.y;
		if (size < bounds.size.z)
			size = bounds.size.z;

		if (Mathf.Abs(1.0f - size) < 0.01f) {
			Debug.Log ("Already unit size");
			return;
		}

		float scale = 1.0f / size;

		Vector3[] verts = mesh.vertices;

		for (int i = 0; i < verts.Length; i++) {
			verts[i] = verts[i] * scale;
		}

		mesh.vertices = verts;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}
}
