using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthTextScript : MonoBehaviour
{
    Animator anim;
    float health;
    Text text;

    void Start()
    {
        anim = GetComponent<Animator>();
        text = GetComponent<Text>();
    }

    public void takeDamage(float newHealth)
    {
        health = newHealth;
        text.text = "Health: " + (int)health;
        anim.SetBool("takeDamage", true);

    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
        text.text = "Health: " + (int)health;
    }
}
