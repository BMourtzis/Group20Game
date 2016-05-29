using UnityEngine;
using System.Collections;

public class WeaponObject : MonoBehaviour
{
    [SerializeField]
    int Ammo;
    [SerializeField]
    GameObject weaponObj;

    public WeaponObject(GameObject weapon, int ammo)
    {
        Ammo = ammo;
        weaponObj = weapon;
    }

    public int getAmmo()
    {
        return Ammo;
    }

    public void setAmmo(int newAmmo)
    {
        Ammo = newAmmo;
    }

    public GameObject getWeapon()
    {
        return weaponObj;
    }

    public void setWeapon(GameObject weapon)
    {
        weaponObj = weapon;
    }
}
