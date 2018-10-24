using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsPanel : MonoBehaviour {

	[SerializeField]
	private GameObject modelsPanelExtra;
	[SerializeField]
	private GameObject deleteConfirmationPanel;
	[SerializeField]
	private GameObject selectionPanel;
	[SerializeField]
	private GameObject modelControlPanel;

	[SerializeField]
    private ModelList modelList;

	public GameObject selectedModel;

	public void ShowModelControlPanel() {
		modelControlPanel.transform.SetAsLastSibling ();
		modelsPanelExtra.SetActive (true);
	}

    public void OnClickAddButton() {
		selectionPanel.transform.SetAsLastSibling ();
		modelsPanelExtra.SetActive (true);
    }

	public void AddLightToScene(GameObject model) {
		GameObject gameObject = Instantiate (model) as GameObject;
		Vector3 camPos = Camera.main.transform.position;
		gameObject.transform.position = new Vector3 (camPos.x + 3, 1, camPos.z + 3);
		gameObject.AddComponent (typeof(VrmiModel));

		modelList.Add (gameObject);
	}

	public void AddModelToScene(GameObject model) {
		GameObject gameObject = Instantiate (model) as GameObject;
		ResizeMeshToUnit (gameObject.transform.GetChild(0).gameObject);
		Vector3 camPos = Camera.main.transform.position;
		gameObject.transform.position = new Vector3 (camPos.x + 3, 1, camPos.z + 3);
		gameObject.AddComponent (typeof(VrmiModel));

		modelList.Add (gameObject);
	}

	public void DoDeleteModel(GameObject gameObject) {
		deleteConfirmationPanel.GetComponent<DeleteConfirmation> ().selections = new GameObject[] {
			gameObject,
			gameObject.GetComponent<ModelListEntry> ().model
		};
		deleteConfirmationPanel.transform.SetAsLastSibling ();
		modelsPanelExtra.SetActive (true);
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

		if (Mathf.Abs(2.0f - size) < 0.01f) {
			Debug.Log ("Already unit size");
			return;
		}

		float scale = 2.0f / size;

		Vector3[] verts = mesh.vertices;

		for (int i = 0; i < verts.Length; i++) {
			verts[i] = verts[i] * scale;
		}

		mesh.vertices = verts;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();

		t.GetComponent<MeshCollider>().sharedMesh = null;
		t.GetComponent<MeshCollider>().sharedMesh = mesh;
	}
}
