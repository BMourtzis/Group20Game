using UnityEngine;
using System.Collections;
using System;

public class WeaponReset : MonoBehaviour
{
    [SerializeField]
    public WeaponSet[] weaponSet;

    // Use this for initialization
    void Start ()
    {
        GameObject[] weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().getWeapons();
	    for(int i = 0; i < weapons.Length && weapons[i] != null; i++)
        {
            if (weaponSet[i].Enabled)
            {
                weapons[i].GetComponent<WeaponScript>().Enable();
            }
            else
            {
                weapons[i].GetComponent<WeaponScript>().Disable();
            }

            weapons[i].GetComponent<WeaponScript>().setAmmo(weaponSet[i].Ammo);
        }
	}
}

[Serializable]
public class WeaponSet
{
    public bool Enabled;
    public int Ammo;
}
