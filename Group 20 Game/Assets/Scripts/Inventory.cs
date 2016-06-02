using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    [SerializeField]
    bool[] Keys;

    int inUse;
    void Update()
    {
        getButtonNumber();
    }
    
    //Weapons
    public void addAmmo(int addAmmo, int wp)
    {
        if(inUse == wp)
        {
            GetComponent<PlayerWeaponsScript>().addAmmo(addAmmo);
        }
        else if(weapons[wp] != null)
        {
            weapons[wp].GetComponent<WeaponScript>().addAmmo(addAmmo);
        }
    }

    public void addWeapon(int wp)
    {
        weapons[wp].GetComponent<WeaponScript>().Enable();
        changeWeapon(weapons[wp], inUse);
        inUse = wp;
    }

    void changeWeapon(GameObject weapon, int prev)
    {
        GameObject wp = GetComponent<PlayerWeaponsScript>().ReplaceWeapon(weapon);
        if(wp != null)
        {
            weapons[prev].GetComponent<WeaponScript>().setAmmo(wp.GetComponent<WeaponScript>().getAmmo());
        }
    }

    void getButtonNumber()
    {
        int selected = 0;
        GameObject newWeapon = null;
        if (Input.GetButtonDown("Number1"))
        {
            newWeapon = weapons[0];
            selected = 0;
        }
        else if (Input.GetButtonDown("Number2"))
        {
            newWeapon = weapons[1];
            selected = 1;
        }
        else if(Input.GetButtonDown("Number3"))
        {
            newWeapon = weapons[2];
            selected = 2;
        }
        else if (Input.GetButtonDown("Number4"))
        {
            newWeapon = weapons[3];
            selected = 3;
        }
        else if (Input.GetButtonDown("Number5"))
        {
            newWeapon = weapons[4];
            selected = 4;
        }

        if(newWeapon != null)
        {
            if (newWeapon.GetComponent<WeaponScript>().getEnabled() && weapons[inUse] != newWeapon)
            {
                changeWeapon(newWeapon, inUse);
                inUse = selected;
            }
        }
    }

    public GameObject[] getWeapons()
    {
        return weapons;
    }

    //Keys
    public bool putKey(int pos)
    {
        return Keys[pos];
    }

    public void getKey(int pos)
    {
        Keys[pos] = true;
    }
}
