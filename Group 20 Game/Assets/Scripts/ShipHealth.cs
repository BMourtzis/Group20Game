using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipHealth : MonoBehaviour {

	public int healthPoints;
	public Text healthText;
	public Text endText;
	//public Spawner spawner

	void OnCollisionEnter2D (Collision2D bomb) {
		if (bomb.gameObject.tag == "Bomb") {
			healthPoints -= 1;
		}
	}

	void FixedUpdate()
	{
		if (healthPoints < 0) {
			healthPoints = 0;
			endText.text = "Your ship was destroyed!";
		}
		healthText.text = "Ship HP: " + healthPoints;
	}

}
