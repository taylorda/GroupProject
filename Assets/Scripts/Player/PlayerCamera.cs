using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerCamera : MonoBehaviour
{
	// Inspector Variables

	public Camera camera;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public bool limitXRotation = false;
	public float minimumX = -360f;
	public float maximumX = 360f;

	public bool limitYRotation = false;
	public float minimumY = -60f;
	public float maximumY = 60f;

	// Private Variables
	Rigidbody rb;

	float rotationX = 0f;
	float rotationY = 0f;

	void Start ()
	{
		// Fetch Rigidbody
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}

	void Update ()
	{
		rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;

		if (limitXRotation) {
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
		}

		if (limitYRotation) {
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		}

		Quaternion rotX = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion rotY = Quaternion.AngleAxis (rotationY, Vector3.left);

		camera.transform.localRotation = rotY;
		transform.localRotation = rotX;
	}
}
