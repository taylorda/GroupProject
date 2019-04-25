using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public int playerID;
	public float speed;

	string horizontalMovementAxis;
	string verticalMovementAxis;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		horizontalMovementAxis = "Horizontal" + playerID;
		verticalMovementAxis = "Vertical" + playerID;
	}

	void Update() {

	}

	void FixedUpdate() {
		float hsp = Input.GetAxis (horizontalMovementAxis);
		float vsp = Input.GetAxis (verticalMovementAxis);

		Vector3 movement = new Vector3 (hsp, vsp, 0f);

		transform.position += movement * speed;
	}
}
