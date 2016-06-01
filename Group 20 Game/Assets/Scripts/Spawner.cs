using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject bomb;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawn()
	{
		Vector3 spawnPosition;
		//while (true) {
			spawnPosition = new Vector3 (Random.Range (-1, 1), transform.position.y, 0);
		//}
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bomb, spawnPosition, spawnRotation);
		yield return new WaitForSeconds (1.0f);
	}
}
