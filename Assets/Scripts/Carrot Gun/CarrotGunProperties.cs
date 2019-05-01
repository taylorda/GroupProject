using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGunProperties : MonoBehaviour {


    public Rigidbody2D projectile;
    public Transform Spawnpoint;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {

            Rigidbody2D clone;
            clone = (Rigidbody2D)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

        }

	}
}
