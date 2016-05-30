using UnityEngine;
using System.Collections;

public class WeaponItem : ItemScript
{
    [SerializeField]
    GameObject weaponObj;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().addWeapon(weaponObj);
            Destroy(gameObject);
        }
    }
}
