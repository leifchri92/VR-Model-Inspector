using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

	[SerializeField]
	private LineRenderer lineRenderer;
	[SerializeField]
	private GameObject[] points;

	void Start() {
		lineRenderer.positionCount = points.Length;

		for (int i = 0; i < points.Length; i++)
			lineRenderer.SetPosition (i, points [i].transform.position);
	}

	public void SetPosition(int index, Vector3 position) {
		if (index >= points.Length)
			return;

		points [index].transform.position = position;
		lineRenderer.SetPosition (index, points [index].transform.position);
	}

	public float GetDistance() {
		print ("Getting distance");
		if (points.Length < 2) {
			Debug.LogError ("Scale: Cannot get distance of single point.");
			return -1;
		}
		print (Vector3.Distance (points [0].transform.position, points [1].transform.position));
		return Vector3.Distance (points [0].transform.position, points [1].transform.position);
	}
}
