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
		bombs = spawner.GetComponent<Spawner>().getBombs();
		if (healthPoints <= 0) {
			healthPoints = 0;
			endText.text = "Your ship was destroyed!";
			StartCoroutine (restartLevel ());
		}
		else if (bombs == 0) {
			endText.color = new Color(0, 201, 84);
			endText.text = "You saved your ship!";
		}
		healthText.text = "Ship HP: " + healthPoints;
	}

	IEnumerator restartLevel() {
		yield return new WaitForSeconds (3);
		Application.LoadLevel (Application.loadedLevel);
	}
}
