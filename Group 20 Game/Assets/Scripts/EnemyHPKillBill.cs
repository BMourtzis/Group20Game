using UnityEngine;
using System.Collections;

public class EnemyHPKillBill : MonoBehaviour
{
	public float HealthPoints;

	// Update is called once per frame
	void Update()
	{
		if (HealthPoints < 0)
		{
			Destroy(gameObject);
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

	public float getHealth()
	{
		return HealthPoints;
	}
}