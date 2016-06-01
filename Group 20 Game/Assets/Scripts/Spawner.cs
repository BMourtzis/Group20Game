using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject bomb;

	// Use this for initialization
	void Start () {
		/*
		for (int i = 0; i < 10; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-1, 1), transform.position.y, 0);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (bomb, spawnPosition, spawnRotation);
		}
		*/
		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawn()
	{
		while (true) {
			Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y, 0);
			if (true)
				Instantiate (bomb, spawnPosition, transform.rotation);
			yield return new WaitForSeconds (1);
		}
	}
}
