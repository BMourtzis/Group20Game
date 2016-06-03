using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
	public GameObject enemy;
	public Text enemyRemainder;
	public Text guideText;

	int enemies;
	int alive;

	void Start()
	{
		enemies = 40;
		StartCoroutine(Spawn());
		alive = enemies;
	}

	void Update() {
		if (alive < 0)
			guideText.text = "You killed them all";
	}

	IEnumerator Spawn()
	{
		guideText.text = "Limited ammo, loads of enemies.";
		yield return new WaitForSeconds(4);
		guideText.text = "Collect ammo that randomly fall from the sky.";
		yield return new WaitForSeconds(4);
		guideText.text = "Good luck";
		yield return new WaitForSeconds(2);
		guideText.text = "";

		while (enemies > 0)
		{
			Vector3 spawnPositionLeft = new Vector3(Random.Range(-40, -30), transform.position.y, 0);
			Vector3 spawnPositionRight = new Vector3(Random.Range(30, 40), transform.position.y, 0);
			if (true)
			{
				Instantiate(enemy, spawnPositionLeft, transform.rotation);
				Instantiate(enemy, spawnPositionRight, transform.rotation);
			}
			enemies -= 1;
			enemyRemainder.text = "Enemies: " + alive;

			yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
		}
	}

	public int getNumOfEnemies()
	{
		return enemies;
	}

	public void setAlive(int killed) {
		alive -= killed;
	}
}