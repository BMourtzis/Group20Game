using UnityEngine;
using System.Collections;

public class tutorialEnemy : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        if(GetComponent<EnemyHealth>().getHealth() < 1)
        {
            GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TutorialText>().EnemyKilledTip();
        }
	}
}
