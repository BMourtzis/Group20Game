using UnityEngine;
using System.Collections;

public class WeaponItem : ItemScript
{
    [SerializeField]
    GameObject weaponObj;
    [SerializeField]
    int InitialAmmo;

    WeaponObject weapon;

    void Start()
    {
        weapon = new WeaponObject(weaponObj, InitialAmmo);
    }

    // Use this for initialization
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().addWeapon(weapon);
            weapon = null;
            Destroy(gameObject);
        }
    }
}
