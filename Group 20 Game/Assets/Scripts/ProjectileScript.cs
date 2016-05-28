using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    [SerializeField]
    float Damage;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.y < -25)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!(other.gameObject.tag == "Player"))
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.SendMessage("TakeDamage", Damage);
            }
            Destroy(gameObject);
        }
    }
}
