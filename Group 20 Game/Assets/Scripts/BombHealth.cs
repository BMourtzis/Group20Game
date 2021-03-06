﻿using UnityEngine;
using System.Collections;

public class BombHealth : MonoBehaviour
{
	public float HealthPoints;

	// Update is called once per frame
	void Update()
	{
		if (HealthPoints < 1)
		{
			HT_Explode explodeScript = GetComponent<HT_Explode> ();
			explodeScript.explodeNow ();
		}
	}

	//Decreases the Health of the Player
	public void TakeDamage(float damage)
	{
		HealthPoints -= damage;
	}

	//Increases the Health of the Player
	public void RecoverHealth(float health)
	{
		HealthPoints += health;
	}
}
