using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthTextScript : MonoBehaviour {

    PlayerHealthScript health;

	// Use this for initialization
	void Start ()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = "Health: " + (int)health.getHealth();
	}
}
