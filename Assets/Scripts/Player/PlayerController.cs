using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public int playerID;
	public float speed;

	public Camera cam;

	public float distanceToMouse { get; private set; }
	public Vector3 directionOfMouse { get; private set; }
	public float angleToMouse { get; private set; }

	string horizontalMovementAxis;
	string verticalMovementAxis;
	Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		horizontalMovementAxis = "Horizontal" + playerID;
		verticalMovementAxis = "Vertical" + playerID;
	}

	void FixedUpdate() {
		float hsp = Input.GetAxis (horizontalMovementAxis);
		float vsp = Input.GetAxis (verticalMovementAxis);

		Vector3 movement = new Vector3 (hsp, vsp, 0f);

		transform.position += movement * speed;

		Vector3 mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 difference = transform.position - mousePosition;

		distanceToMouse = difference.magnitude;
		directionOfMouse = difference.normalized * -1;
		angleToMouse = Mathf.Atan2 (directionOfMouse.y, directionOfMouse.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis (angleToMouse, Vector3.forward);
	}
}
