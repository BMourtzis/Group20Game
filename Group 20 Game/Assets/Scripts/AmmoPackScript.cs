using UnityEngine;
using System.Collections;

public class AmmoPackScript : ItemScript
{

    [SerializeField]
    int Ammo;
    [SerializeField]
    int weapon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().addAmmo(Ammo, weapon);
            Destroy(gameObject);
            Ammo = 0;
        }
    }
}
