using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnvironmentalObject : MonoBehaviour {
	protected Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
}
