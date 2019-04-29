using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {
	public int mapWidth;
	public int mapHeight;
	[HideInInspector] public List<EnvironmentalObject> objects;

	void Start () {
		transform.localScale = new Vector3 (mapWidth, mapHeight, 1);
		objects = new List<EnvironmentalObject> ();
	}

	void Update () {
		
	}
}
