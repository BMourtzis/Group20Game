using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoTextScript : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        if(GameObject.FindGameObjectWithTag("Weapon") != null)
        {
            int ammo = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponScript>().getAmmo();
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
