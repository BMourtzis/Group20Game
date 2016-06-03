// This script was developed by Guan for the level 'Fall of Guam'

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject bomb;
	public Text bombRemainder;
	public Text guideText;
	public float dragReduction;
	public float dropDelayReduction;
	public float minDrag;
	public float minDelay;

	float linearDrag;
	float dropDelay;
	int numOfBombs;

	void Start () {
		// Initial hardcoded values optimized through testing.
		linearDrag = 10;
		dropDelay = 2.0f;
		numOfBombs = 40;

		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		// Bombs will drop quicker and more often as time progresses.
		guideText.text = "Shoot the bombs before it destroys your ship!";
		yield return new WaitForSeconds (4);
		guideText.text = "There is ammo located around the turrets of the ship!";
		yield return new WaitForSeconds (4);
		guideText.text = "Good luck!";
		yield return new WaitForSeconds (2);
		guideText.text = "";

		while (numOfBombs > 0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-3, 94), transform.position.y, 0);
			if (true) {
				GameObject bombClone = (GameObject) Instantiate (bomb, spawnPosition, transform.rotation);
				bombClone.GetComponent<Rigidbody2D> ().drag = linearDrag;
			}
			numOfBombs -= 1;
			bombRemainder.text = "Bombs: " + numOfBombs;
			nextWave ();

			yield return new WaitForSeconds (dropDelay);
		}
	}

	void nextWave()
	{
		if (linearDrag > minDrag)
			linearDrag -= dragReduction;
		if (dropDelay > minDelay)
			dropDelay -= dropDelayReduction;
	}

	public int getBombs() {
		return numOfBombs;
	}
}
