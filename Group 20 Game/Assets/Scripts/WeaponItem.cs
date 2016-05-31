using UnityEngine;
using System.Collections;

public class WeaponItem : ItemScript
{
    [SerializeField]
    int weapon;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().addWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
