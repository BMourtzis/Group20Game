using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

    [SerializeField]
    float HealthPoints;

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints > 0)
        {
            //End game;
        }
    }

    //Decreases the Health of the Player
    public void TakeDamage(float damage, bool right)
    {
        HealthPoints -= damage;
        Vector2 force;
        if (right) { force = transform.right; }
        else { force = transform.right*-1; }
        GetComponent<Rigidbody2D>().AddForce(force * 400);
    }

    //Increases the Health of the Player
    public void RecoverHealth(float health)
    {
        HealthPoints += health;
    }
}
