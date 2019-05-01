using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
	public float dampTime = 0.2f;
	public float screenEdgeBuffer = 4f;
	public float minSize = 6.5f;
	public Transform[] targets;

	private Camera cam;
	private Vector3 moveVelocity;
	private float zoomSpeed;

	void Awake() {
		cam = GetComponentInChildren<Camera> ();
	}

	void FixedUpdate() {
		Vector3 averagePosition = new Vector3 ();
		int numTargets = 0;
		for (int i = 0; i < targets.Length; i++) {
			if (!targets [i].gameObject.activeSelf)
				continue;
			averagePosition += targets [i].position;
			numTargets++;
		}
		if (numTargets > 1) {
			averagePosition /= numTargets;
		}
		averagePosition.z = transform.position.z;

		transform.position = Vector3.SmoothDamp (transform.position, averagePosition, ref moveVelocity, dampTime);

		Vector3 desiredLocalPos = transform.InverseTransformPoint (averagePosition);

		float size = 0f;

		for (int i = 0; i < targets.Length; i++) {
			if (!targets [i].gameObject.activeSelf)
				continue;
			Vector3 targetLocalPos = transform.InverseTransformPoint (targets [i].position);
			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.z));
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y) / cam.aspect);
		}

		size += screenEdgeBuffer;
		size = Mathf.Max (size, minSize);
		cam.orthographicSize = Mathf.SmoothDamp (cam.orthographicSize, size, ref zoomSpeed, dampTime);
	}
}
