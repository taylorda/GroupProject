using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public int playerID;
	public float speed;
	public GameObject bullet;
	public float targetSpeed;
	public float bulletSpeed;

	string horizontalMovementAxis;
	string verticalMovementAxis;

	string crosshairXAxis;
	string crosshairYAxis;

	Vector3 targetPosition = Vector3.zero;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		horizontalMovementAxis = "Horizontal" + playerID;
		verticalMovementAxis = "Vertical" + playerID;
		crosshairXAxis = "Crosshair X" + playerID;
		crosshairYAxis = "Crosshair Y" + playerID;
	}

	void Update() {
		FaceMouse ();
	}

	void FixedUpdate() {
		float hsp = Input.GetAxis (horizontalMovementAxis);
		float vsp = Input.GetAxis (verticalMovementAxis);

		Vector3 movement = new Vector3 (hsp, vsp, 0f);

		transform.position += movement * speed;


	}

	void FaceMouse(){
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		Vector3 called = transform.position - mousePosition;
		float distance = called.magnitude;
		Vector3 direction = called.normalized;
	}

}
