using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoTextScript : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        GameObject wp = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().getWeaponInUse();
        if (wp != null)
        {
            int ammo = wp.GetComponent<WeaponScript>().getAmmo();
            if(ammo > 0)
            {
                GetComponent<Text>().text = "Ammo: " + ammo;
            }
            else
            {
                GetComponent<Text>().text = "Ammo: Empty";
            }
        }
	}
}
