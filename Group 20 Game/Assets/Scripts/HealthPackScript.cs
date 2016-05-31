using UnityEngine;
using System.Collections;

public class HealthPackScript : ItemScript {

    [SerializeField]
    int Health;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealthScript>().RecoverHealth(Health);
            Destroy(gameObject);
        }
    }
}
