using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    int inUse;
    void Update()
    {
        getButtonNumber();
    }

    public GameObject getWeapon(int item)
    {
        return weapons[item - 1];
    }

    public void addWeapon(GameObject weapon)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == null)
            {
                weapons[i] = weapon;
                changeWeapon(weapons[i], inUse);
                inUse = i;
                break;
            }
        }
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
            newWeapon = getWeapon(1);
            selected = 0;
        }
        else if (Input.GetButtonDown("Number2"))
        {
            newWeapon = getWeapon(2);
            selected = 1;
        }
        else if(Input.GetButtonDown("Number3"))
        {
            newWeapon = getWeapon(3);
            selected = 2;
        }
        else if (Input.GetButtonDown("Number4"))
        {
            newWeapon = getWeapon(4);
            selected = 3;
        }
        else if (Input.GetButtonDown("Number5"))
        {
            newWeapon = getWeapon(5);
            selected = 4;
        }

        if(newWeapon != null && weapons[inUse] != newWeapon)
        {
            changeWeapon(newWeapon,inUse);
            inUse = selected;
        }
    }
}
