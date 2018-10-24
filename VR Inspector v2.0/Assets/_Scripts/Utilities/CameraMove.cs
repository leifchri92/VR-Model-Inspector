using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CameraMove : MonoBehaviour {

	[SerializeField]
	private Transform playerCamera;

	public float moveSpeed = 3.0f;
	public float lookSpeed = 2.0f;

	public float yaw = 0.0f;
	public float pitch = 0.0f;

	private CharacterController controller;

	void Start() {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		float rightSpeed = Input.GetAxis("Horizontal") * moveSpeed;
		float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * forwardSpeed);
		Vector3 right = transform.TransformDirection (Vector3.right);
		controller.SimpleMove(right * rightSpeed);

		if (Input.GetMouseButton (1)) 
		{
			yaw += lookSpeed * Input.GetAxis("Mouse X");
			pitch -= lookSpeed * Input.GetAxis("Mouse Y");

			playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		}
	}
}