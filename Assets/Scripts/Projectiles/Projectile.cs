using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Projectile : MonoBehaviour {
	public Vector3 direction;
	public float damage;
	public float speed;
	public float lifetime;
	public float size;
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.forward * speed;
	}

	void FixedUpdate () {
		
	}


}
