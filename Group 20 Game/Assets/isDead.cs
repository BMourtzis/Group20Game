using UnityEngine;
using System.Collections;

public class isDead : MonoBehaviour {

	private GameObject controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<EnemyHealth> ().getHealth () < 0)
			controller.GetComponent<WaveSpawner>().setAlive(1);
	}
}
