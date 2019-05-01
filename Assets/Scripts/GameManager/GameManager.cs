using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject environmentPrefab;
	public GameObject playerPrefab;

	public Vector2 minBoundarySize = Vector2.zero;
	public Vector2 maxBoundarySize = Vector2.one;
	public int seed = 0;

	private int playerID = 0;

	public Environment environment;
	public Cam cameraRig;

	void Start () {
		string[] joysticks = Input.GetJoystickNames ();

		cameraRig.targets = new Transform[joysticks.Length];

		for (var i = 0; i < joysticks.Length; i++) {
			PlayerController pc = Instantiate (playerPrefab).GetComponent<PlayerController> ();
			cameraRig.targets [playerID] = pc.transform;
			pc.playerID = ++playerID;
		}

		if (joysticks.Length == 0) {
			PlayerController pc = Instantiate (playerPrefab).GetComponent<PlayerController> ();
			pc.playerID = ++playerID;
			cameraRig.targets = new Transform[] { pc.transform };
		}

		Random.InitState (seed);
		NewEnvironment ();
	}

	void OnValidate() {
		Vector2 originalMinSize = minBoundarySize;
		Vector2 originalMaxSize = maxBoundarySize;
		minBoundarySize.x = Mathf.Min (originalMaxSize.x, originalMinSize.x);
		minBoundarySize.y = Mathf.Min (originalMaxSize.y, originalMinSize.y);
		maxBoundarySize.x = Mathf.Max (originalMaxSize.x, originalMinSize.x);
		maxBoundarySize.y = Mathf.Max (originalMaxSize.y, originalMinSize.y);
	}

	void NewEnvironment() {
		Environment newEnvrionment = Instantiate (environmentPrefab).GetComponent<Environment> ();
		newEnvrionment.mapWidth = (int) Random.Range(minBoundarySize.x, maxBoundarySize.x);
		newEnvrionment.mapHeight = (int) Random.Range(minBoundarySize.y, maxBoundarySize.y);
		newEnvrionment.Generate ();
		environment = newEnvrionment;
	}

	void Update () {
		
	}
}
