using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonsterKillEndScript : MonoBehaviour
{
    EnemyHealth health;

	// Use this for initialization
	void Start ()
    {
        health = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(health.getHealth() < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
