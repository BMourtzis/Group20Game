using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    [SerializeField]
    float HealthPoints;
	
	// Update is called once per frame
	void Update ()
    {
	    if(HealthPoints > 0)
        {
            //End game;
        }
	}

    //Decreases the Health of the Player
    public void TakeDamage(float damage)
    {
        HealthPoints -= damage;
        //Vector3 newPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        //transform.position = newPos;
    }

    //Increases the Health of the Player
    public void RecoverHealth(float health)
    {
        HealthPoints += health;
    }
}
