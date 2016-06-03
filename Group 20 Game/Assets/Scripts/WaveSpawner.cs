using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

	void Update() {
		
		if (searchAlive () == false && enemies <= 0)
			StartCoroutine (winGame ());
		enemyRemainder.text = "Enemies: " + GameObject.FindGameObjectsWithTag ("Enemy").Length/2;
	}

	bool searchAlive() {
		if (GameObject.FindGameObjectWithTag ("Enemy") == null)
			return false;
		return true;
	}

	IEnumerator winGame()
	{
		guideText.text = "You killed them all";
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	IEnumerator Spawn()
	{
		guideText.text = "Loads of ammo, loads of enemies.";
		yield return new WaitForSeconds(4);
		guideText.text = "Kill them all.";
		yield return new WaitForSeconds(2);
		guideText.text = "Have fun";
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
			enemies -= 2;
			yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
		}
	}

	public int getNumOfEnemies()
	{
		return enemies;
	}
}