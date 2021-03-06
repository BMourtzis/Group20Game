﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField]
    float HealthPoints;
    [SerializeField]
    HealthTextScript text;

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints > 101)
        {
            HealthPoints -= Time.deltaTime;
        }
        else if (HealthPoints <= 0)
        {
            HealthPoints = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        text.setHealth(HealthPoints);
    }

    //Decreases the Health of the Player
    public void TakeDamage(float damage, bool right)
    {
        HealthPoints -= damage;
        text.takeDamage(HealthPoints);
        Vector2 force;
        if (right) { force = transform.right; }
        else { force = transform.right * -1; }
        GetComponent<Rigidbody2D>().AddForce(force * 400);
        GetComponent<MovementScript>().pushedBack();
    }

    public void TakeDamage(float damage)
    {
        HealthPoints -= damage;
        text.takeDamage(HealthPoints);
    }

    // Used in Guan's level to get hurt by bomb.
    void OnCollisionEnter2D(Collision2D bomb)
    {
        bool right;
        if (Random.Range(0.0f, 1.0f) < 0.5f)
            right = false;
        else
            right = true;
        if (bomb.gameObject.tag == "Bomb")
            TakeDamage(20, right);
    }

    //Increases the Health of the Player
    public void RecoverHealth(float health)
    {
        HealthPoints += health;
    }
}
