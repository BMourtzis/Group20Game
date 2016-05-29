using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    [SerializeField]
    WeaponObject[] weapons;

    public WeaponObject getWeapon(int item)
    {
        return weapons[item - 1];
    }

    public void addWeapon(WeaponObject weapon)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == null)
            {
                weapons[i] = weapon;
                changeWeapon(weapons[i]);
                break;
            }
        }
    }

    void changeWeapon(WeaponObject weapon)
    {
        GetComponent<PlayerWeaponsScript>().ReplaceWeapon(weapon);
    }
}
