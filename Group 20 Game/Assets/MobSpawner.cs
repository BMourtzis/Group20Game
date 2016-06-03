// This script was developed by Guan for the level 'Fall of Guam' modified by Lachlan slightly

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MobSpawner : MonoBehaviour
{

    public GameObject enemy;
    public Text enemyRemainder;
    public Text guideText;

    float spawnDelay;
    int numOfenemys;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        // Bombs will drop quicker and more often as time progresses.
        guideText.text = "Limited ammo, unlimited* enemys. Goodluck!";
        yield return new WaitForSeconds(4);
        guideText.text = "*The enemys may be limited";
        yield return new WaitForSeconds(4);
        guideText.text = "";

        while (numOfenemys > 0)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
            if (true)
            {
                GameObject enemyClone = (GameObject)Instantiate(enemy, spawnPosition, transform.rotation);
            }
            numOfenemys -= 1;
            enemyRemainder.text = "enemys: " + numOfenemys;

            yield return new WaitForSeconds(1);
        }
    }


    public int getBombs()
    {
        return numOfenemys;
    }
}
