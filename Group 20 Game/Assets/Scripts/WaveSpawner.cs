using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
	public GameObject enemy;
	public Text enemyRemainder;
	public Text guideText;

	int enemies;

	void Start()
	{
		enemies = 40;
		StartCoroutine(Spawn());
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
			Vector3 spawnPosition = new Vector3(-40, transform.position.y, 0);
			if (true)
			{
				Instantiate(enemy, spawnPosition, transform.rotation);
			}
			enemies -= 1;
			enemyRemainder.text = "Enemies: " + enemies;

			yield return new WaitForSeconds(1);
		}
	}

	public int getNumOfEnemies()
	{
		return enemies;
	}
}