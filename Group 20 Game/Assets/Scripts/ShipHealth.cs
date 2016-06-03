using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipHealth : MonoBehaviour {

	public int healthPoints;
	public Text healthText;
	public Text endText;
	public GameObject spawner;

	int bombs;

	void OnCollisionEnter2D (Collision2D bomb) {
		if (bomb.gameObject.tag == "Bomb") {
			healthPoints -= 1;
		}
	}

	void FixedUpdate()
	{
		// Deals with win or loss:
		bombs = spawner.GetComponent<Spawner>().getBombs();
		if (healthPoints <= 0) {
			failLevel ();
		}
		else if (bombs == 0) {
			StartCoroutine (winLevel());
		}

		healthText.text = "Ship HP: " + healthPoints;
	}

	void failLevel() {
		healthPoints = 0;
		endText.text = "Your ship was destroyed!";
		StartCoroutine (restartLevel ());
	}

	IEnumerator winLevel() {
		// Sometimes there are still bombs in the air
		yield return new WaitForSeconds (4);
		if (healthPoints > 0) {
			endText.color = new Color (0, 201, 84);
			endText.text = "You saved your ship!";
		}
		// Move to Next Level
		StartCoroutine (nextLevel());
	}

	IEnumerator restartLevel() {
		yield return new WaitForSeconds (3);
		Application.LoadLevel (Application.loadedLevel);
	}

	IEnumerator nextLevel() {
		yield return new WaitForSeconds (3);
		Application.LoadLevel (0);
	}
}
