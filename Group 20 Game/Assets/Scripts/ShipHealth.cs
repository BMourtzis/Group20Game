using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipHealth : MonoBehaviour {

	public int healthPoints;
	public Text healthText;

	void OnCollisionEnter2D (Collision2D bomb) {
		if (bomb.gameObject.tag == "Enemy") {
			healthPoints -= 1;
		}
	}

	void FixedUpdate()
	{
		healthText.text = "Ship HP: " + healthPoints;
	}

}
