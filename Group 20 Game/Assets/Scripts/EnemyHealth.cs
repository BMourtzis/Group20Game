using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float HealthPoints;

    bool kill;

    void Start()
    {
        kill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(kill)
        {
            Destroy(transform.parent.gameObject);
        }

        if (HealthPoints < 1)
        {
            kill = true;
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
